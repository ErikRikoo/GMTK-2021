﻿using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrowdEntity : MonoBehaviour
{
    [SerializeField] private Vector2Variable m_Goal;
    [SerializeField] private float m_AvoidanceDistance;
    [SerializeField] private Animator _animator;
    [SerializeField]
    private SphereCollider m_TriggerCollider;
    
    private Pathfinding.IAstarAI m_AstarAI;

    private bool m_HasReachedGoal = true;
    private int _animatorWalkingHash;
    private int _animatorWalkOffsetHash;
    private Rigidbody m_Rigidbody;
    
    public bool HasReachedGoal
    {
        get => m_HasReachedGoal;
        set
        {
            m_HasReachedGoal = value;
            OnHasReachedGoalChanged();
        }
    }

    private void OnHasReachedGoalChanged()
    {
        m_AstarAI.canMove = !HasReachedGoal;
        _animator.SetBool(_animatorWalkingHash, !HasReachedGoal);
        m_TriggerCollider.enabled = HasReachedGoal;
        
        if (HasReachedGoal)
        {
            m_Rigidbody.constraints |= RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            m_Rigidbody.constraints ^= RigidbodyConstraints.FreezeRotationY;
        }
    }

    private void Awake()
    {
        _animatorWalkingHash = Animator.StringToHash("walking");
        _animatorWalkOffsetHash = Animator.StringToHash("WalkCycleOffset");
        
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AstarAI = GetComponent<IAstarAI>();
        
        UpdateTriggerCollider();
        
        m_Goal.Changed.Register(OnGoalChanged);
        OnGoalChanged(m_Goal.Value);

        _animator.SetFloat(_animatorWalkOffsetHash, Random.value);
    }

    private void UpdateTriggerCollider()
    {
        m_TriggerCollider.radius = m_AvoidanceDistance;
    }

    private void OnValidate()
    {
        UpdateTriggerCollider();
    }

    private void InitTriggerCollider()
    {
        m_TriggerCollider = gameObject.AddComponent<SphereCollider>();
        m_TriggerCollider.isTrigger = true;
    }

    private void OnGoalChanged(Vector2 newValue)
    {
        HasReachedGoal = false;
        m_AstarAI.destination = new Vector3(newValue.x, 0, newValue.y);
        _animator.SetBool(_animatorWalkingHash, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (HasReachedGoal)
        {
            return;
        }
        if (other.TryGetComponent(out CrowdEntity entity))
        {
            if (entity.HasReachedGoal)
            {
                HasReachedGoal = true;
            }
        }
        
    }
}

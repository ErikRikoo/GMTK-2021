using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CrowdEntity : MonoBehaviour
{
    [SerializeField] private Vector2Variable m_Goal;
    [SerializeField] private float m_AvoidanceDistance;
    
    
    private Pathfinding.IAstarAI m_AstarAI;

    private bool m_HasReachedGoal = true;

    [SerializeField]
    private SphereCollider m_TriggerCollider;
    
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
    }

    private void Awake()
    {
        m_AstarAI = GetComponent<IAstarAI>();
        UpdateTriggerCollider();
        m_Goal.Changed.Register(OnGoalChanged);
        OnGoalChanged(m_Goal.Value);
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

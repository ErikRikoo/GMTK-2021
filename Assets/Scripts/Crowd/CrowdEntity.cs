using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrowdEntity : MonoBehaviour
{
    [SerializeField] private Vector2Variable m_Goal;
    [SerializeField] private float m_AvoidanceDistance;
    [SerializeField] private Animator _animator;
    [SerializeField] private SphereCollider m_TriggerCollider;
    [SerializeField] private GameObjectValueList m_crowd;
    [SerializeField] private CrowdEntityList m_FollowingList;
    
    
    [SerializeField] private bool m_HasReachedGoal = false;
    
    private Pathfinding.IAstarAI m_AstarAI;

    private int _animatorWalkingHash;
    private int _animatorWalkOffsetHash;
    private Rigidbody m_Rigidbody;
    

    public bool HasReachedGoal
    {
        get => m_HasReachedGoal;
        set
        {
            if (m_Goal == null)
            {
                return;
            }
            m_HasReachedGoal = value;
            OnHasReachedGoalChanged();
        }
    }
    
    private void OnHasReachedGoalChanged()
    {
        ChangeMovementState(!HasReachedGoal);
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

    private void ChangeMovementState(bool IsMoving)
    {
        m_AstarAI.canMove = IsMoving;
        _animator.SetBool(_animatorWalkingHash, IsMoving);
    }

    private void Awake()
    {
        m_crowd.Add(gameObject);

        m_GoalChangedListener = new GoalCHangedListener(this);
        _animatorWalkingHash = Animator.StringToHash("walking");
        _animatorWalkOffsetHash = Animator.StringToHash("WalkCycleOffset");
        
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AstarAI = GetComponent<IAstarAI>();
        
        UpdateTriggerCollider();
        if (m_Goal != null)
        {
            RegisterGoalMovement();
        }
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
        m_AstarAI.destination = new Vector3(newValue.x, 0, newValue.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!HasReachedGoal)
        {
            return;
        }
        if (other.TryGetComponent(out CrowdEntity entity))
        {
            entity.HasReachedGoal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!HasReachedGoal)
        {
            return;
        }
        if (other.TryGetComponent(out CrowdEntity entity))
        {
            HasReachedGoal = false;
        }
    }

    public void FollowTarget(Vector2Variable goalVariable)
    {
        if (m_Goal == goalVariable)
        {
            return;
        }
        
        if (m_Goal != null)
        {
            UnregisterGoalMovement();
        }
        m_Goal = goalVariable;
        RegisterGoalMovement();
    }

    public void RemoveTarget(Vector2Variable oldTarget)
    {
        if (m_Goal == oldTarget)
        {
            UnregisterGoalMovement();
            ChangeMovementState(false);
            m_Goal = null;
        }
    }

    private GoalCHangedListener m_GoalChangedListener;
    private void RegisterGoalMovement()
    {
        m_Goal.Changed.RegisterListener(m_GoalChangedListener);
        m_GoalChangedListener.OnEventRaised(m_Goal.Value);
        HasReachedGoal = false;
    }

    private void UnregisterGoalMovement()
    {
        m_Goal.Changed.UnregisterListener(m_GoalChangedListener);
    }

    private class GoalCHangedListener : IAtomListener<Vector2>
    {
        private CrowdEntity motherInstance;

        public GoalCHangedListener(CrowdEntity motherInstance)
        {
            this.motherInstance = motherInstance;
        }

        public void OnEventRaised(Vector2 newPos)
        {
            motherInstance.OnGoalChanged(newPos);
        }
    }

    public void Die()
    {
        _animator.SetBool("die", true);
        m_AstarAI.canMove = false;
        m_FollowingList?.List.RemoveAll(element => element == this);
        Destroy(gameObject, 3.0f);
    }
}

using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityTemplateProjects.Crowd
{
    [RequireComponent(typeof(SphereCollider))]
    public class CrowdGatherer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float m_GatherRadius = 3;

        [SerializeField] private bool m_LoseCrowdWhenFar = false;
        
        [Header("Variables")]
        [SerializeField] private Vector2Variable m_GoalVariable;

        private SphereCollider m_Collider;

        private void Awake()
        {
            InitCollider();
            UpdateCollider();
        }

        private void OnValidate()
        {
            if (m_Collider == null)
            {
                InitCollider();
            }

            UpdateCollider();
        }

        private void InitCollider()
        {
            m_Collider = GetComponent<SphereCollider>();
        }
        
        private void UpdateCollider()
        {
            m_Collider.radius = m_GatherRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CrowdEntity entity))
            {
                entity.FollowTarget(m_GoalVariable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!m_LoseCrowdWhenFar)
            {
                return;
            }
            
            if (other.gameObject.TryGetComponent(out CrowdEntity entity))
            {
                entity.RemoveTarget(m_GoalVariable);
            }
        }
    }
}
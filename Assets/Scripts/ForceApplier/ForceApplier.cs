using System;
using ForceApplier;
using Triggerable.Trigger;
using UnityEngine;

namespace UnityTemplateProjects.ForceApplier
{
    [RequireComponent(typeof(Collider))]
    public class ForceApplier : MonoBehaviour
    {
        [SerializeField] private ColliderFilterSO m_Filter;
        [SerializeField] private ForceApplySO m_ForceApply;

        private Collider m_Collider;

        private void Awake()
        {
            m_Collider = GetComponent<Collider>();
        }

        private void OnTriggerStay(Collider other)
        {
            CheckColliderAndApplyForce(other);
        }

        private void CheckColliderAndApplyForce(Collider other)
        {
            if (m_Filter.IsColliderValid(other))
            {
                m_ForceApply.ApplyForce(m_Collider, other.gameObject);
            }
        }
    }
}
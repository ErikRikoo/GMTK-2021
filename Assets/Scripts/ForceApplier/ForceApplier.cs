using ForceApplier;
using Triggerable.Trigger;
using UnityEngine;

namespace UnityTemplateProjects.ForceApplier
{
    public class ForceApplier : MonoBehaviour
    {
        [SerializeField] private ColliderFilterSO m_Filter;
        [SerializeField] private ForceApplySO m_ForceApply;
        
        private void OnTriggerStay(Collider other)
        {
            CheckColliderAndApplyForce(other);
        }

        private void CheckColliderAndApplyForce(Collider other)
        {
            if (m_Filter.IsColliderValid(other))
            {
                m_ForceApply.ApplyForce(gameObject, other.gameObject);
            }
        }
    }
}
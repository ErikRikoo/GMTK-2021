using UnityEngine;

namespace Triggerable.Trigger
{
    [CreateAssetMenu(fileName = "DynamicLayerFilter", menuName = "Triggerable/Filter/Layer Mask", order = 0)]
    public class DynamicLayerFilter : ColliderFilterSO
    {
        [SerializeField] private LayerMask m_LayerMaskFilter;
        
        public override bool IsColliderValid(Collider collider)
        {
            return ((1 << collider.gameObject.layer) & m_LayerMaskFilter) != 0;
        }
    }
}
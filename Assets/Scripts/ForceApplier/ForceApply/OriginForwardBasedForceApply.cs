using UnityEngine;

namespace ForceApplier.ForceApply
{
    [CreateAssetMenu(fileName = "OriginForwardBasedForceApply", menuName = "Force Applier/Apply/ Origin Forward Based", order = 0)]
    public class OriginForwardBasedForceApply : ForceApplySO
    {
        [SerializeField] private float m_Strength;

        public override void ApplyForce(Collider origin, GameObject target)
        {
            if (target.TryGetComponent(out Rigidbody targetRigidBody))
            {
                targetRigidBody.AddForce(origin.transform.forward * m_Strength);
            }
        }
    }
}
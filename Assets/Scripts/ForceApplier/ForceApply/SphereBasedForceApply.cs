using UnityEngine;

namespace ForceApplier.ForceApply
{
    [CreateAssetMenu(fileName = "SphereBasedForceApply", menuName = "Force Applier/Apply/Sphere Based", order = 0)]
    public class SphereBasedForceApply : ForceApplySO
    {
        [SerializeField] private float m_Strength;

        public override void ApplyForce(Collider origin, GameObject target)
        {
            if (target.TryGetComponent(out Rigidbody targetRigidBody))
            {
                Vector3 direction = target.transform.position - origin.transform.position;
                direction.y = 0;
                direction.Normalize();
                targetRigidBody.AddForce(direction * m_Strength);
            }
        }
    }
}
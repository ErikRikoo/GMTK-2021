using UnityEngine;

namespace ForceApplier.ForceApply
{
    [CreateAssetMenu(fileName = "DistanceBasedForceApply", menuName = "Force Applier/Apply/ Distance Based", order = 0)]
    public class DistanceBasedForceApply : ForceApplySO
    {
        [SerializeField] private float m_Strength;
        [SerializeField] private AnimationCurve m_DistanceToStrengthMultiplier;

        public override void ApplyForce(Collider origin, GameObject target)
        {
            if (target.TryGetComponent(out Rigidbody targetRigidBody))
            {
                Vector3 halfBounds = origin.bounds.size * 0.5f;
                float colliderRadius = halfBounds.magnitude;
                Vector3 axis = origin.transform.right;
                float distanceOnAxis =
                    Vector3.Dot(axis, (target.transform.localPosition - origin.transform.localPosition).normalized);
                distanceOnAxis = Mathf.Clamp01(Mathf.Abs(distanceOnAxis));
                float strengthMultiplier = m_DistanceToStrengthMultiplier.Evaluate(1 - distanceOnAxis);

                targetRigidBody.AddForce(origin.transform.forward * (m_Strength * strengthMultiplier));
            }
        }
    }
}
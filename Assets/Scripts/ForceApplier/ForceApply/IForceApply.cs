using UnityEngine;

namespace ForceApplier
{
    public interface IForceApply
    {
        void ApplyForce(Collider origin, GameObject target);
    }
}
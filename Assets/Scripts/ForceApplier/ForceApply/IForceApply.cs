using UnityEngine;

namespace ForceApplier
{
    public interface IForceApply
    {
        void ApplyForce(GameObject origin, GameObject target);
    }
}
using UnityEngine;

namespace ForceApplier
{
    public abstract class ForceApplySO : ScriptableObject, IForceApply
    {
        public abstract void ApplyForce(Collider origin, GameObject target);
    }
}
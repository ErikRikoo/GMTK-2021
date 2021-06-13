using UnityEngine;

namespace ForceApplier
{
    public abstract class ForceApplySO : ScriptableObject, IForceApply
    {
        public abstract void ApplyForce(GameObject origin, GameObject target);
    }
}
using UnityEngine;

namespace Triggerable.Trigger
{
    public abstract class ColliderFilterSO : ScriptableObject, IColliderFilter
    {
        public abstract bool IsColliderValid(Collider collider);
    }
}
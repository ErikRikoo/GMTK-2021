using UnityEngine;

namespace Triggerable.Trigger
{
    public abstract class ColliderOfTypeObject<T> : ColliderFilterSO
    {
        public override bool IsColliderValid(Collider collider)
        {
            return collider.gameObject.TryGetComponent<T>(out T _);
        }
    }
}
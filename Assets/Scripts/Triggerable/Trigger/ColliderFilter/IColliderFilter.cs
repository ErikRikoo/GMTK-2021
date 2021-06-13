using UnityEngine;

namespace Triggerable.Trigger
{
    public interface IColliderFilter
    {
        bool IsColliderValid(Collider collider);
    }
}
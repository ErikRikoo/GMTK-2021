using System.Linq;
using UnityEngine;

namespace Triggerable.Trigger 
{
	[CreateAssetMenu(fileName = "AllColliderFilter", menuName = "Triggerable/Filter/All Collider Filter", order = 0)]

    public class AllColliderFilter : ColliderFilterSO
    {
        [SerializeField] ColliderFilterSO[] ColliderFilters;
        public override bool IsColliderValid(Collider collider)
        {
            return ColliderFilters.All(element => element.IsColliderValid(collider));
        }
    }
}

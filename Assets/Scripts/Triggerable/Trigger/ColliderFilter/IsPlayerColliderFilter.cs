using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Triggerable.Trigger 
{
	[CreateAssetMenu(fileName = "IsPlayerColliderFilter", menuName = "Triggerable/Filter/IsPlayer Collider Filter", order = 0)]
    public class IsPlayerColliderFilter : ColliderFilterSO
    {
        public override bool IsColliderValid(Collider collider)
		{
			return collider.gameObject.CompareTag("Player");
		}
    }
}
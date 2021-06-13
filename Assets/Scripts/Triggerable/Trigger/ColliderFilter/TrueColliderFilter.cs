using UnityEngine;

namespace Triggerable.Trigger 
{
	[CreateAssetMenu(fileName = "TrueColliderFilter", menuName = "Triggerable/Filter/True Collider Filter", order = 0)]
	public class TrueColliderFilter: ColliderFilterSO
	{
		public override bool IsColliderValid(Collider collider)
		{
			return true;
		}	
	}	
}

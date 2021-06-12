using UnityEngine;

namespace Crowd.CrowdExternalInteraction.CrowdGather
{
    [RequireComponent(typeof(Collider))]
    public class CrowdCollisionGatherer : CrowdEntityGatherer
    {
        private void OnTriggerEnter(Collider other)
        {
            InteractWithEntityIfPossible(other.gameObject);
        }
    }
}
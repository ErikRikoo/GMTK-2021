using System;
using UnityEngine;

namespace Crowd.CrowdExternalInteraction.CrowdUngather
{
    public class CrowdCollisionUngatherer : CrowdEntityUngather
    {
        private void OnTriggerExit(Collider other)
        {
            InteractWithEntityIfPossible(other.gameObject);
        }
    }
}
using UnityEngine;

namespace Crowd.CrowdExternalInteraction.CrowdUngather
{
    public abstract class CrowdEntityUngather : CrowdEntityInteractor
    {
        public override void InteractWithEntity(CrowdEntity entity)
        {
            entity.RemoveTarget(m_GoalVariable);
        }
    }
}
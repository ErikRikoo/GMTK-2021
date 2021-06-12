namespace Crowd.CrowdExternalInteraction.CrowdGather
{
    public abstract class CrowdEntityGatherer : CrowdEntityInteractor
    {
        public override void InteractWithEntity(CrowdEntity entity)
        {
            entity.FollowTarget(m_GoalVariable);
        }
    }
}
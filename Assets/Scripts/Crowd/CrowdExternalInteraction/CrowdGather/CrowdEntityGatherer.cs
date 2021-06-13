using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Crowd.CrowdExternalInteraction.CrowdGather
{
    public abstract class CrowdEntityGatherer : CrowdEntityInteractor
    {
        [Header("Variables")]
        [SerializeField] protected Vector2Variable m_GoalVariable;
        [SerializeField] private CrowdEntityList m_Storage;
        
        
        public override void InteractWithEntity(CrowdEntity entity)
        {
            m_Storage.List.RemoveAll(element => element == entity);
            m_Storage?.Add(entity);
            entity.FollowTarget(m_GoalVariable);
        }
    }
}
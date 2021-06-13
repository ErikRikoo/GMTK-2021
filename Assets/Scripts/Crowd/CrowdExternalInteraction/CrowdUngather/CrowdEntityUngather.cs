using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Crowd.CrowdExternalInteraction.CrowdUngather
{
    public abstract class CrowdEntityUngather : CrowdEntityInteractor
    {
        [Header("Variables")]
        [SerializeField] protected Vector2Variable m_GoalVariable;
        [SerializeField] private CrowdEntityList m_Storage;

        public override void InteractWithEntity(CrowdEntity entity)
        {
            m_Storage?.Remove(entity);
            entity.RemoveTarget(m_GoalVariable);
        }
    }
}
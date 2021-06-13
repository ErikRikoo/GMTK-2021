using System;
using Crowd.CrowdExternalInteraction;
using Crowd.CrowdExternalInteraction.CrowdGather;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityTemplateProjects.PhaseHandling
{
    public class OnENdCrowdGather : CrowdEntityInteractor
    {
        [SerializeField] private CrowdEntityList m_FollowingList;
        [SerializeField] private VoidEvent m_EndGame;
        
        
        private int m_TriggerCount;
        
        public override void InteractWithEntity(CrowdEntity entity)
        {
            entity.gameObject.SetActive(false);
            ++m_TriggerCount;

            if (m_TriggerCount >= m_FollowingList.Count)
            {
                m_EndGame?.Raise();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            InteractWithEntityIfPossible(other.gameObject);
        }
    }
}
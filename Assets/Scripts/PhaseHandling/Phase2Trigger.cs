using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityTemplateProjects.PhaseHandling
{
    public class Phase2Trigger : MonoBehaviour
    {
        [Header("Event")]
        [SerializeField] private VoidEvent m_StartPhase2;
        
        [Header("Variables")]
        [SerializeField] private CrowdEntityList m_FollowingList;
        [SerializeField] private Vector2Variable m_NewGoal;
        [SerializeField] private FloatVariable m_SpeedVariable;
        [SerializeField] private FloatConstant m_NewSpeedConstant;


        private void Awake()
        {
            m_StartPhase2.Register(StartPhase);
        }

        private void StartPhase()
        {
            foreach (var entity in m_FollowingList.List)
            {
                entity.FollowTarget(m_NewGoal);
            }
        }
    }
}
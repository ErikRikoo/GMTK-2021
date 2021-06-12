using System;
using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityTemplateProjects.Timer
{
    public class TimerHandler : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] private FloatVariable m_CurrentTime;
        [SerializeField] private FloatVariable m_MaxTime;
        
        [Header("Event")] 
        [SerializeField] private FloatEvent m_StartTimer;
        [SerializeField] private FloatEvent m_OnTimerChanged;
        [SerializeField] private VoidEvent m_OnTimerEnd;

        [Header("Config")]
        [SerializeField] private float m_RefreshRate;

        private Coroutine m_TimerCoroutine;
        

        private void Awake()
        {
            m_StartTimer.Register(StartTimer);
        }

        private void StartTimer(float newMaxTime)
        {
            m_CurrentTime.Value = 0;
            m_MaxTime.Value = newMaxTime;
            m_TimerCoroutine = StartCoroutine(TimingCoroutine());
        }

        private IEnumerator TimingCoroutine()
        {
            do
            {
                m_OnTimerChanged.Raise(m_CurrentTime.Value);
                yield return new WaitForSeconds(m_RefreshRate);
                m_CurrentTime.Value += m_RefreshRate;
            } while (m_CurrentTime.Value < m_MaxTime.Value);

            m_CurrentTime.Value = m_MaxTime.Value;
            m_OnTimerChanged.Raise(m_MaxTime.Value);
        }
        
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CrowdSpeedChanger : MonoBehaviour
{
    [SerializeField] private FloatVariable m_SpeedVariable;

    private IAstarAI m_AstarAI;
    
    private void Awake()
    {
        m_AstarAI = GetComponent<IAstarAI>();
        if (m_SpeedVariable != null)
        {
            m_SpeedVariable.Changed.Register(OnSpeedChanged);
            OnSpeedChanged(m_SpeedVariable.Value);
        }

    }

    private void OnSpeedChanged(float newSpeed)
    {
        m_AstarAI.maxSpeed = newSpeed;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CrowdGoal : MonoBehaviour
{
    [SerializeField] private Vector2Variable m_Variable;

    [SerializeField]
    private bool m_ShouldTrigger = true;

    public bool ShouldTrigger
    {
        get => m_ShouldTrigger;
        set {
            m_ShouldTrigger = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.z);
        if (pos != m_Variable.Value)
        {
            m_Variable.Value = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ShouldTrigger)
        {
            return;
        }
        
        if (other.gameObject.TryGetComponent(out CrowdEntity entity))
        {
            entity.HasReachedGoal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out CrowdEntity entity))
        {
            entity.HasReachedGoal = false;
        }
    }
}

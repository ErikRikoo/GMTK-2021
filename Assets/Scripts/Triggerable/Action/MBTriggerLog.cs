using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects.Triggerable.Action;

public class MBTriggerLog : MonoBehaviour, ITriggerable
{
    public void Trigger()
    {
        Debug.Log("Triggered", this);
    }
}

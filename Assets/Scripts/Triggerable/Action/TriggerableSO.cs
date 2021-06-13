using UnityEngine;

namespace UnityTemplateProjects.Triggerable.Action
{
    public abstract class TriggerableSO : ScriptableObject, ITriggerable
    {
        public abstract void Trigger();
    }
}
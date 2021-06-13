using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityTemplateProjects.Triggerable.Action
{
    [CreateAssetMenu(fileName = "ActionTriggerable", menuName = "Triggerable/Action Triggerable", order = 0)]
    public class ActionTriggerable : TriggerableSO
    {
        [SerializeField] private VoidEvent m_EventToTrigger;

        public override void Trigger()
        {
            m_EventToTrigger?.Raise();
        }
    }
}
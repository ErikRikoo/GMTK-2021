using UnityEngine;

namespace UnityTemplateProjects.Triggerable.Action
{
    [CreateAssetMenu(fileName = "DebugTriggerable", menuName = "Triggerable/Debug Triggerable", order = 0)]
    public class DebugTriggerable : TriggerableSO
    {
        [SerializeField] private string m_Message;
        
        public override void Trigger()
        {
            Debug.Log(m_Message);
        }
    }
}
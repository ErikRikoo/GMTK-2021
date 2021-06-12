using System;
using UnityEngine;
using UnityTemplateProjects.Triggerable.Action;
using Object = System.Object;

namespace UnityTemplateProjects.Triggerable
{
    public class BaseTrigger : MonoBehaviour
    {
        [Tooltip("Should be or contain a ITriggerable")]
        [SerializeField] private UnityEngine.Object m_TriggerableInstance;
        private ITriggerable m_InstanceCasted;

        protected void OnValidate()
        {
            TryCastInstance();
        }

        private void TryCastInstance()
        {
            if (m_TriggerableInstance == null)
            {
                return;
            }

            if (TryCastTo(m_TriggerableInstance, out m_InstanceCasted))
            {
                return;
            }
            
            if (TryCastTo(m_TriggerableInstance, out GameObject go))
            {
                TryGetTriggerableFromGO(go);
                return;
            }

            if (TryCastTo(m_TriggerableInstance, out Component component))
            {
                TryGetTriggerableFromGO(component.gameObject);
                return;
            }
        }

        private bool TryCastTo<T>(Object instance, out T ret)
        where T : class
        {
            ret = instance as T;
            return ret != null;
        }

        private void TryGetTriggerableFromGO(GameObject go)
        {
            m_InstanceCasted = go.GetComponent<ITriggerable>();
            if (m_InstanceCasted == null)
            {
                m_TriggerableInstance = null;
                Debug.LogError("The given instance should be or contain an ITriggerable", this);
            }
        }

    }
}
using UnityEngine;
using UnityTemplateProjects.Triggerable;

namespace Triggerable.Trigger
{
    [RequireComponent(typeof(Collider))]
    public abstract class BaseTriggerEnterTriggerable : BaseTrigger
    {
        protected abstract IColliderFilter Filter
        {
            get;
        }

        protected abstract void OnCountChanged(int newCount, int delta);

        private int m_Count;
        
        private void OnTriggerEnter(Collider other)
        {
            CheckColliderAndAddDelta(other, 1);
        }

        private void OnTriggerExit(Collider other)
        {

            CheckColliderAndAddDelta(other, -1);
        }

        private void CheckColliderAndAddDelta(Collider other, int delta)
        {
            if (Filter.IsColliderValid(other))
            {
                m_Count += delta;
                OnCountChanged(m_Count, delta);
            }

            if (m_Count < 0)
            {
                Debug.LogError("We have Count lower than zero, issue detected");
            }
        }
    }
}
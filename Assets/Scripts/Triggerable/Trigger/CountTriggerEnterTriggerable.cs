using UnityEngine;

namespace Triggerable.Trigger
{
    public class CountTriggerEnterTriggerable : BaseTriggerEnterTriggerable
    {
        [SerializeField] private ColliderFilterSO m_FilterSo;

        [SerializeField] public int m_RequiredCount;
        
        protected override IColliderFilter Filter => m_FilterSo;
        protected override void OnCountChanged(int newCount, int delta)
        {
            if (newCount >= m_RequiredCount)
            {
                InstanceCasted.Trigger();
            }
        }
    }
}
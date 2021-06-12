using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Crowd.CrowdExternalInteraction
{
    public abstract class CrowdEntityInteractor : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] protected Vector2Variable m_GoalVariable;

        public void InteractWithEntityIfPossible(GameObject potentialEntity)
        {
            if (potentialEntity.TryGetComponent(out CrowdEntity entity))
            {
                InteractWithEntity(entity);
            }
        }

        public abstract void InteractWithEntity(CrowdEntity entity);
    }
}
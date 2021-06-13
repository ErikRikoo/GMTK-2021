using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityTemplateProjects.Triggerable.Action {
    public class SpawnHermitCrabTrigger : MonoBehaviour, ITriggerable 
    {
        [SerializeField] CrowdEntity SpawnableEntity;
        [SerializeField] Vector3 SpawnPosition;
        [SerializeField] Vector2Variable CrabGoal;

        public void Trigger() {
            CrowdEntity newHermitCrab;
            newHermitCrab = Instantiate(SpawnableEntity, SpawnPosition, Quaternion.identity);
            newHermitCrab.FollowTarget(CrabGoal);
        }
    }
}

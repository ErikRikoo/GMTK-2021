using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace UnityTemplateProjects.Triggerable.Action
{
    public class GateOpenTrigger : Openable
    {
        [SerializeField] Animator animator;

        private int m_OpenHash;

        private void Awake()
        {
            m_OpenHash = Animator.StringToHash("open");
            StartCoroutine(c_Foo());
        }

        private IEnumerator c_Foo()
        {
            yield return new WaitForSeconds(1.5f);
            GetComponent<Collider>().enabled = true;
        }

        public override void OnOpen()
        {
            animator.SetBool(m_OpenHash, true);

            GetComponent<Collider>().enabled = false;
        }
    }
}
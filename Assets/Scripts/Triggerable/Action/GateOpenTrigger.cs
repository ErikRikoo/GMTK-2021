using System.Collections;
using System.Collections.Generic;
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
        }

        public override void OnOpen()
        {
            animator.SetBool(m_OpenHash, true);
        }
    }
}
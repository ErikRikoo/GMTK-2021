using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityTemplateProjects.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform m_Target;
        [SerializeField] private float m_MovementSpeed;

        [SerializeField] private Transform m_LookAtTarget;
        
        private void Awake()
        {
            transform.position = m_Target.position;
        }

        void LateUpdate()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            Vector3 goal = m_Target.position;
            
            Vector3 nextPosition = Vector3.LerpUnclamped(transform.position, goal, m_MovementSpeed);
            transform.position = nextPosition;
            transform.LookAt(m_LookAtTarget.position, Vector3.forward);
        }
    }
}
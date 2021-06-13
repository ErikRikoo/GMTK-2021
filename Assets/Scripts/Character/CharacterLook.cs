using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class CharacterLook : MonoBehaviour
    {
        private UnityEngine.Camera m_MainCamera;
        
        private Plane m_GroundPlane = new Plane(Vector3.up, 0.0f);

        private void Awake()
        {
            m_MainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (m_GroundPlane.Raycast(ray, out float rayPos))
            {
                Vector3 worldMousePos = ray.GetPoint(rayPos);
                Vector3 direction = worldMousePos - transform.position;
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }
    }
}
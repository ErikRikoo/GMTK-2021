using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class CharacterClick : MonoBehaviour
    {
        [SerializeField] private GameObject m_Effect;
        [Tooltip("-1 for no destroy")]
        [SerializeField] private float m_Delay;

        [SerializeField] private Transform m_PlaceCenter;
        
        
        private UnityEngine.Camera m_MainCamera;

        private Plane m_GroundPlane = new Plane(Vector3.up, 0.0f);
        
        private void Awake()
        {
            m_MainCamera = UnityEngine.Camera.main;
            enabled = false;
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
            {
                return;
            }
            
            if (!enabled)
            {
                return;
            }
            
            Ray ray = m_MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (m_GroundPlane.Raycast(ray, out float rayPos))
            {
                Vector3 worldMousePos = ray.GetPoint(rayPos);
                InstantiateEffectAt(worldMousePos);
            }
        }

        private void InstantiateEffectAt(Vector3 pos)
        {
            if (m_Effect != null)
            {
                GameObject obj = Instantiate(m_Effect, pos, m_PlaceCenter.rotation);
                Vector3 dir = pos - m_PlaceCenter.position;
                float dot = Vector3.Dot(m_PlaceCenter.forward, dir);
                if (dot > 0)
                {
                    obj.transform.Rotate(Vector3.up * 180f);
                }
                
                if (m_Delay > 0)
                {
                    Destroy(obj, m_Delay);
                    
                }
                
            }
            
            
        }
    }
}
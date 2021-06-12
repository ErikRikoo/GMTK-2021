using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float m_Speed;

        private Coroutine m_MovementCoroutine;
    
        public void OnMovement(InputAction.CallbackContext input)
        {
            if (input.phase == InputActionPhase.Started)
            {
                if (m_MovementCoroutine != null)
                {
                    StopCoroutine(m_MovementCoroutine);
                }
                m_MovementCoroutine = StartCoroutine(MovementRoutine(input));
            } else if (input.phase == InputActionPhase.Canceled)
            {
                if (m_MovementCoroutine != null)
                {
                    StopCoroutine(m_MovementCoroutine);
                }
            }
        }

        private IEnumerator MovementRoutine(InputAction.CallbackContext input)
        {
            while (true)
            {
                Move(input.ReadValue<Vector2>());
                yield return null;
            }
        }

        private void Move(Vector2 movement)
        {
            movement *= m_Speed * Time.deltaTime;
            Vector3 newPos = transform.localPosition;
            newPos.x += movement.x;
            newPos.z += movement.y;
            transform.localPosition = newPos;
        }
    }
}

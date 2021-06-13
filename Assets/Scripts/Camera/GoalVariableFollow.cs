using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Camera
{
    public class GoalVariableFollow : MonoBehaviour
    {
        [SerializeField] private Vector2Variable m_Goal;
        [SerializeField] private Vector3 m_Offset;

        private void Awake()
        {
            m_Goal.Changed.Register(OnGoalChanged);
            OnGoalChanged(m_Goal.Value);
        }

        private void OnGoalChanged(Vector2 newPos)
        {
            Vector3 temp = new Vector3(newPos.x, 0, newPos.y);
            temp += m_Offset;
            transform.position = temp;
        }
    }
}
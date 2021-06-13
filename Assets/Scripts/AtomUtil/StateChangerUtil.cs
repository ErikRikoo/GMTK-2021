using UnityEngine;

namespace UnityTemplateProjects.AtomUtil
{
    public class StateChangerUtil : MonoBehaviour
    {
        public void ChangeState(bool newState)
        {
            gameObject.SetActive(newState);
        }
    }
}
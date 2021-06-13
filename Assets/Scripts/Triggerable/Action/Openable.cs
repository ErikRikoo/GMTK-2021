using UnityEngine;


namespace UnityTemplateProjects.Triggerable.Action
{
	public abstract class Openable: MonoBehaviour, ITriggerable
	{
		private bool m_IsOpen = false;
		
		public bool IsOpen => m_IsOpen;
		public abstract void OnOpen();
		
		public void Trigger() 
		{
			if (m_IsOpen == false) {
				m_IsOpen = true;
				OnOpen();	
			}
		}
	}
}


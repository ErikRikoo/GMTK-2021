using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTemplateProjects.Triggerable.Action
{
	public class VerticalGateBehaviour : Openable
	{
		[SerializeField] private Vector3 m_OpeningVector;
		
		public override void OnOpen()
		{
			transform.position += m_OpeningVector;
		}
	}
}

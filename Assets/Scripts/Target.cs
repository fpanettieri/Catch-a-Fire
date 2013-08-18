using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
	private Extinguisher m_extinguisher;
	
	public void OnTriggerEnter(Collider other)
	{
		if (m_extinguisher != null) { return; }
		if (other.GetType() != typeof(CapsuleCollider)){ return; }
		
		Extinguisher extinguisher = other.transform.parent.GetComponent<Extinguisher>();
		if(extinguisher == null){ return; }
		
		m_extinguisher = extinguisher;
	}
	
	public void OnTriggerExit(Collider other)
	{
		if (m_extinguisher == null) { return; }
		if (other.GetType() != typeof(CapsuleCollider)){ return; }
		
		Extinguisher extinguisher = other.transform.parent.GetComponent<Extinguisher>();
		if(extinguisher != m_extinguisher){ return; }
		
		m_extinguisher = null;
	}
}

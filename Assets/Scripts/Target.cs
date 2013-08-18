using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
	private Extinguisher m_extinguisher;
	private Quaternion m_rotation;
	
	public void FixedUpdate()
	{
		if( m_extinguisher == null) { return; }
		m_rotation = Quaternion.Lerp(m_extinguisher.transform.rotation, Quaternion.identity, 0.1f);
		m_extinguisher.transform.rotation = m_rotation;
	}
	
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

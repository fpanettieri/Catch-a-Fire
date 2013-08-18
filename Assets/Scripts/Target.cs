using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
	public GameObject m_circle;
	public GameObject m_center;
	
	public TargetState state { get { return m_state; } }
	
	private TargetState m_state;
	private Extinguisher m_extinguisher;
	
	public void Start()
	{
		m_state = TargetState.Empty;
	}
	
	public void FixedUpdate()
	{
		if (m_extinguisher == null){ return; }
		
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if (m_extinguisher != null) { return; }
		if (other.GetType() != typeof(CapsuleCollider)){ return; }
		
		Extinguisher extinguisher = other.transform.parent.GetComponent<Extinguisher>();
		if(extinguisher == null){ return; }
		
		m_extinguisher = extinguisher;
		m_state = TargetState.Hover;
		UpdateColor();
	}
	
	public void OnTriggerExit(Collider other)
	{
		if (m_extinguisher == null) { return; }
		if (other.GetType() != typeof(CapsuleCollider)){ return; }
		
		Extinguisher extinguisher = other.transform.parent.GetComponent<Extinguisher>();
		if(extinguisher != m_extinguisher){ return; }
		
		m_extinguisher = null;
		m_state = TargetState.Empty;
		UpdateColor();
	}
	
	private void UpdateColor()
	{
		Color color = Color.magenta;
		switch(m_state){
			case TargetState.Empty: color = Color.white;  break;
			case TargetState.Hover: color = Color.yellow; break;
			case TargetState.Good:  color = Color.green;  break;
			case TargetState.Bad:   color = Color.red;    break;
		}
		m_circle.renderer.material.color = color;
		m_center.renderer.material.color = color;
	}
}

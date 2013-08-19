using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
	// injected dependencies
	public GameObject m_circle;
	public GameObject m_center;
	public Score m_score;
	
	// state accessor for objectives
	public TargetState state { get { return m_state; } }
	
	// internal state
	private Extinguisher m_extinguisher;
	private TargetState m_state;
	private int m_calculatedScore;
	
	public void Start()
	{
		m_state = TargetState.Empty;
		m_calculatedScore = 0;
	}
	
	public void FixedUpdate()
	{
		if (m_extinguisher == null){ return; }
		
		if (m_extinguisher.rigidbody.IsSleeping()) {
			
			if(m_extinguisher.transform.up.y >= .9){
				changeState( TargetState.Good );
				// TODO: play success sound
				
			} else {
				changeState( TargetState.Bad );
				// TODO: play error sound
			}
			
		} else {
			changeState( TargetState.Hover );
		}
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if (m_extinguisher != null) { return; }
		if (other.GetType() != typeof(CapsuleCollider)){ return; }
		
		Extinguisher extinguisher = other.transform.parent.GetComponent<Extinguisher>();
		if(extinguisher == null){ return; }
		
		m_extinguisher = extinguisher;
		changeState( TargetState.Hover );
	}
	
	public void OnTriggerExit(Collider other)
	{
		if (m_extinguisher == null) { return; }
		if (other.GetType() != typeof(CapsuleCollider)){ return; }
		
		Extinguisher extinguisher = other.transform.parent.GetComponent<Extinguisher>();
		if(extinguisher != m_extinguisher){ return; }
		
		m_extinguisher = null;
		changeState( TargetState.Empty );
	}
	
	private void changeState(TargetState _state)
	{
		if(m_state == _state){ return; }
		
		if(m_state == TargetState.Good){ 
			m_score.SubstractScore(m_calculatedScore);
		}
		
		if(_state == TargetState.Good){
			AddScore();
		}
		
		m_state = _state;
		UpdateColor(_state);
	}
	
	private void AddScore()
	{
		float distance = Vector3.Distance(m_extinguisher.transform.position, transform.position );
		
		if( distance < 0.125f ){
			m_calculatedScore = m_score.m_extinguisher;
		} else {
			float multiplier = Mathf.Clamp( 1 - distance, 0.1f, 1f);
			m_calculatedScore = Mathf.RoundToInt( multiplier * m_score.m_extinguisher );
		}

		m_score.AddScore(m_calculatedScore);
	}
	
	private void UpdateColor( TargetState _state )
	{
		Color color = Color.magenta;
		switch(_state){
			case TargetState.Empty: color = Color.white;  break;
			case TargetState.Hover: color = Color.yellow; break;
			case TargetState.Good:  color = Color.green;  break;
			case TargetState.Bad:   color = Color.red;    break;
		}
		
		m_circle.renderer.material.color = color;
		m_center.renderer.material.color = color;
	}
}

using UnityEngine;
using System.Collections;

public class Finger : MonoBehaviour
{
	private const float IDLE_TIME = 0.1f;
	
	private bool m_idle;
	private float m_idleTime;
	
	public void Start ()
	{
		m_idle = true;
		collider.enabled = false;
	}
	
	public void Update ()
	{
		if(m_idle){ return; }
		
		m_idleTime -= Time.deltaTime;
		if(m_idleTime > 0){ return; }
		
		m_idle = true;
		collider.enabled = false;
	}
	
	public void Move(Vector3 _position)
	{
		m_idle = false;
		m_idleTime = IDLE_TIME;
		collider.enabled = true;
		_position.y = transform.position.y;
		transform.position = _position;
	}
}

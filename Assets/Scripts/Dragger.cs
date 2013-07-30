using UnityEngine;
using System.Collections;

public class Dragger : MonoBehaviour
{
	private const float IDLE_TIME = 0.2f;
	
	public bool dragging { get { return !m_idle; } }
	
	private bool m_idle;
	private float m_idleTime;
	private SpringJoint m_joint;
	
	public void Start ()
	{
		m_idle = true;
		m_joint = GetComponent<SpringJoint>();
	}
	
	public void Update ()
	{
		if(m_idle){ return; }
		
		m_idleTime -= Time.deltaTime;
		if(m_idleTime > 0){ return; }
		
		m_idle = true;
		m_joint.connectedBody = null;
	}
	
	public void Grab(Draggable _draggable, Vector3 _position)
	{
		m_idle = false;
		m_idleTime = IDLE_TIME;
		m_joint.connectedBody = _draggable.rigidbody;
		
		_position.y = transform.position.y;
		transform.position = _position;
	}
	
	public void Drag(Vector3 _position)
	{
		m_idle = false;
		m_idleTime = IDLE_TIME;
		
		_position.y = transform.position.y;
		transform.position = _position;
	}
}

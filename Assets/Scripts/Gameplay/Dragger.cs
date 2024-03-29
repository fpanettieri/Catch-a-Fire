﻿using UnityEngine;
using System.Collections;

public class Dragger : MonoBehaviour
{
	private const float IDLE_TIME = 0.2f;
	
	public bool dragging { get { return !m_idle; } }
	
	private bool m_idle;
	private float m_idleTime;
	private ConfigurableJoint m_joint;
	private Draggable m_draggable;
	
	public void Start ()
	{
		m_idle = true;
		m_joint = GetComponent<ConfigurableJoint>();
	}

	public void Update ()
	{
		if(m_idle){ return; }
		
		m_idleTime -= Time.deltaTime;
		if(m_idleTime > 0){ return; }
		
		m_idle = true;
		m_joint.connectedBody.AddForce(0, -30, 0);
		m_joint.connectedBody = null;
		
		m_draggable.dragger = null;
	}
	
	public void Grab(Draggable _draggable, Vector3 _position)
	{
		Drag(_position);
		
		Vector3 position = transform.position;
		transform.position = _position;
		m_joint.connectedBody = _draggable.rigidbody;
		transform.position = position;
		
		m_draggable = _draggable;
		m_draggable.dragger = this;
	}
	
	public void Drag(Vector3 _position)
	{
		m_idle = false;
		m_idleTime = IDLE_TIME;
		
		transform.position = _position;
	}
}

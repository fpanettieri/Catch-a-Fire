﻿using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour
{
	public GameObject[] m_fingers;
	public GameObject[] m_draggers;
	
	public bool m_mouseEnabled;
	public bool m_touchEnabled;
	
	private Ray m_ray;
	private RaycastHit m_hit;
	private Draggable m_draggable;
	
	private const int OBJECTS_MASK = 1 << 14 | 1 << 17;
	private const int PUSH_MASK = 1 << 11;
	private const int DRAG_MASK = 1 << 12;
	
	public void Start()
	{
		Input.simulateMouseWithTouches = true;	
	}
	
	public void Update ()
	{
		if(m_mouseEnabled){
			MouseInput();
		}
		
		if(m_touchEnabled){
			TouchInput();
		}
	}
	
	private void MouseInput()
	{
		if(Input.GetMouseButtonDown(0)){
			m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			ProcessTouch(m_ray, 0, TouchPhase.Began);
			
		} else if(Input.GetMouseButtonUp(0)){
			m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			ProcessTouch(m_ray, 0, TouchPhase.Ended);
			
		} else if(Input.GetMouseButton(0)){
			m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			ProcessTouch(m_ray, 0, TouchPhase.Moved);
		}
	}
	
	private void TouchInput()
	{
		foreach(Touch touch in Input.touches) {
			m_ray = Camera.main.ScreenPointToRay(touch.position);
			ProcessTouch(m_ray, touch.fingerId, touch.phase);
		}
	}
	
	private void ProcessTouch(Ray _ray, int _fingerId, TouchPhase _phase)
	{
		if( ShouldDrag(_ray, _fingerId, _phase) ){
			Drag(_ray, _fingerId);
			
		} else if( ShouldGrab(_ray, _fingerId, _phase) ){
			Grab(m_draggable, _fingerId);
		
		} else if( ShouldPush(_ray, _fingerId, _phase) ){
			Push(_ray, _fingerId);
		}
	}

	private bool ShouldDrag(Ray _ray, int _fingerId, TouchPhase _phase)
	{
		if( _fingerId >= m_draggers.Length ){ return false; }
		if( _phase == TouchPhase.Canceled || _phase == TouchPhase.Ended ){ return false; }
		
		Dragger dragger = m_draggers[_fingerId].GetComponent<Dragger>();
		if( dragger.dragging ){ return true; }
		
		return false;
	}

	private bool ShouldGrab(Ray _ray, int _fingerId, TouchPhase _phase)
	{
		if( _fingerId >= m_draggers.Length ){ return false; }
		if( _phase != TouchPhase.Began ){ return false; }
		
		if( !Physics.Raycast(m_ray, out m_hit, 100, OBJECTS_MASK) ) { return false; }
		
		Transform parent = m_hit.collider.gameObject.transform.parent;
		if(parent  == null) { return false; }
		
		m_draggable = parent.gameObject.GetComponent<Draggable>();
		return m_draggable != null;
	}
	
	private bool ShouldPush(Ray _ray, int _fingerId, TouchPhase _phase)
	{
		if( _fingerId >= m_fingers.Length ){ return false; }
		if( _phase == TouchPhase.Ended ){ return false; }
		return true;
	}
	
	private void Drag(Ray _ray, int _fingerId)
	{
		if( !Physics.Raycast(m_ray, out m_hit, 100, DRAG_MASK) ) { return; }
		
		Dragger dragger = m_draggers[_fingerId].GetComponent<Dragger>();
		dragger.Drag(m_hit.point);
	}
	
	private void Grab(Draggable _draggable, int _fingerId)
	{
		Dragger dragger = m_draggers[_fingerId].GetComponent<Dragger>();
		dragger.Grab(_draggable, m_hit.point);
	}

	
	private void Push(Ray _ray, int _fingerId)
	{
		if( !Physics.Raycast(m_ray, out m_hit, 100, PUSH_MASK) ) { return; }
		
		Finger finger = m_fingers[_fingerId].GetComponent<Finger>();
		finger.Move(m_hit.point);
	}
}

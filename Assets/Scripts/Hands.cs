using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour
{
	public GameObject[] m_fingers;
	public GameObject[] m_draggers;
	
	private Ray m_ray;
	private RaycastHit m_hit;
	private Draggable m_draggable;
	
	private const int OBJECTS_MASK = 1 << 10 | 1 << 9;
	private const int ROOM_MASK = 1 << 8;
	
	public void FixedUpdate ()
	{
		if(Input.GetMouseButton(0)){
			m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			ProcessTouch(m_ray, 0);
		}
		
		foreach(Touch touch in Input.touches) {
			m_ray = Camera.main.ScreenPointToRay(touch.position);
			ProcessTouch(m_ray, touch.fingerId);
		}
	}
	
	private void ProcessTouch(Ray _ray, int _fingerId)
	{
		if( ShouldDrag(_ray, _fingerId) ){
			Drag(_ray, _fingerId);
			
		} else if( ShouldGrab(_ray, _fingerId) ){
			Grab(m_draggable, _fingerId);
		
		} else if( ShouldPush(_ray, _fingerId) ){
			Push(_ray, _fingerId);
		}
	}

	private bool ShouldDrag(Ray _ray, int _fingerId)
	{
		if( _fingerId >= m_draggers.Length ){ return false; }
		
		Dragger dragger = m_draggers[_fingerId].GetComponent<Dragger>();
		if( dragger.dragging ){ return true; }
		
		return false;
	}

	private void Drag(Ray _ray, int _fingerId)
	{
		Physics.Raycast(m_ray, out m_hit, 100, ROOM_MASK);
		Debug.DrawLine (m_ray.origin, m_hit.point);
		
		Dragger dragger = m_draggers[_fingerId].GetComponent<Dragger>();
		dragger.Drag(m_hit.point);
	}

	private bool ShouldGrab(Ray _ray, int _fingerId)
	{
		if( _fingerId >= m_draggers.Length ){ return false; }
		
		Physics.Raycast(m_ray, out m_hit, 100, OBJECTS_MASK);
		Debug.DrawLine (m_ray.origin, m_hit.point);
		
		if(m_hit.collider == null) { return false; }
		
		m_draggable = m_hit.collider.gameObject.GetComponent<Draggable>();
		return m_draggable != null;
	}
	
	private void Grab(Draggable _draggable, int _fingerId)
	{
		Dragger dragger = m_draggers[_fingerId].GetComponent<Dragger>();
		dragger.Grab(_draggable, m_hit.point);
	}

	private bool ShouldPush(Ray _ray, int _fingerId)
	{
		if( _fingerId >= m_fingers.Length ){ return false; }
		return true;
	}
	
	private void Push(Ray _ray, int _fingerId)
	{
		Physics.Raycast(m_ray, out m_hit, 100, ROOM_MASK);
		Debug.DrawLine (m_ray.origin, m_hit.point);
		
		Finger finger = m_fingers[_fingerId].GetComponent<Finger>();
		finger.Move(m_hit.point);
	}
}

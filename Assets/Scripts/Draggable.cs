using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
	public bool grabbed { get; set; }
	
	private SpringJoint m_joint;
	
	public void Start()
	{
		
	}
	
	public void Grab(RaycastHit hit)
	{
		//Debug.Log("grab");
		grabbed = true;
	}
	
	public void Drag(RaycastHit hit)
	{
		//Debug.Log("drag");
		grabbed = true;
	}
	
	public void Drop(RaycastHit hit)
	{
		rigidbody.isKinematic = false;
		
		//Debug.Log("drop");
		grabbed = false;
	}
}
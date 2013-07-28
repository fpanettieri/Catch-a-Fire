using UnityEngine;
using System.Collections;

public class PuppeteerBehaviour : MonoBehaviour
{
	private Touch touch;
	private Camera camera;
	private Ray ray;
	private RaycastHit hit;
	
	// Use this for initialization
	void Start()
	{
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update()
	{
		for(int i = 0; i < Input.touchCount; i++) {
			touch = Input.GetTouch(i);
			ray = camera.ScreenPointToRay(touch.position);
			Physics.Raycast(ray, out hit);
			Debug.DrawLine (ray.origin, hit.point);
			
			// chekc the hit object is draggable
		}
	}
}
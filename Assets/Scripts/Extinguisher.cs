using UnityEngine;
using System.Collections;

public class Extinguisher : MonoBehaviour
{
	private float m_lastHit;
	private float m_magnitude;
	
	public void Start()
	{
		rigidbody.centerOfMass = new Vector3(0, 1, 0);
		m_lastHit = 0 ;
	}

	public void OnCollisionStay(Collision collision)
	{
		if(Time.time - m_lastHit < 0.3f){ return; }
		m_magnitude = collision.relativeVelocity.magnitude;
		
		if(m_magnitude < 1){ return; }
		m_lastHit = Time.time;
		
		audio.PlayOneShot(audio.clip, m_magnitude * m_magnitude);
	}
}

using UnityEngine;
using System.Collections;

public class Extinguisher : MonoBehaviour
{
	private float m_lastHit;
	
	public void Start()
	{
		m_lastHit = 0 ;
	}

	public void OnCollisionEnter()
	{
		if(Time.time - m_lastHit < 0.25f){ return; }
		m_lastHit = Time.time;
		audio.PlayOneShot(audio.clip);
	}
}

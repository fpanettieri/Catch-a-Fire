using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour
{
	// injected dependency
	public Transform m_target;
	
	// internal state
	private Vector3 m_position;
	private float m_size;
	private Vector3 m_scale;
	
	public void Start()
	{
		Update();
		m_position = new Vector3();
		m_scale = new Vector3();
	}

	public void Update()
	{
		m_position.Set(m_target.position.x, 0.01f, m_target.position.z);
		transform.position = m_position;
		
		m_size = Mathf.Clamp( 1 - m_target.position.y * 0.2f , 0.5f, 1f);
		m_scale.Set(m_size, 1, m_size);
		transform.localScale = m_scale;
	}
}

using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	// injected dependency
	public UILabel m_label;
	
	// configuration
	public int m_time;
	
	public void Start()
	{
		UpdateLabel();
	}
	
	public void Pause()
	{
		CancelInvoke("UpdateLabel");
	}
	
	public void Resume()
	{
		InvokeRepeating("UpdateLabel", 1, 1);
	}
	
	private void UpdateLabel()
	{
		m_label.text = Mathf.RoundToInt( m_time-- ).ToString();
	}
}

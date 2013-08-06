using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	public int m_time;
	public UILabel m_label;
	
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

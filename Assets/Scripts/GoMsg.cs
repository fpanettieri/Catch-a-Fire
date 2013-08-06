using UnityEngine;
using System.Collections;

public class GoMsg : MonoBehaviour
{
	public UILabel m_label;
	public Timer m_timer;
	
	private int m_display;
	
	public void Start ()
	{
		m_display = 3;
		UpdateMsg();
	}
	
	public void UpdateMsg()
	{
		m_label.text = m_display.ToString();
		
		if(--m_display >= 0) {
			Invoke("UpdateMsg", 1);
			return;
		}
		
		m_timer.Resume();
		Destroy(gameObject);
	}
}

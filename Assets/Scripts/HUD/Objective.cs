using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour
{
	// injected dependency
	public UILabel m_label;
	public Target[] m_targets;
	
	private int m_total;
	private int m_current;
	
	public void Start()
	{
		m_current = 0;
		m_total = m_targets.Length;
		UpdateLabel();
	}
	
	public void FixedUpdate()
	{
		int count = 0;
		
		for(int i = 0; i < m_targets.Length; i++){
			if(m_targets[i].state == TargetState.Good){
				count++;
			}
		}
		
		if(count == m_current) { return; }
		
		m_current = count;
		UpdateLabel();
	}
	
	private void UpdateLabel()
	{
		m_label.text = m_current.ToString() + "\n" + m_total.ToString();
	}
		
}

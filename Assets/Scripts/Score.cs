using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	// injected dependency
	public UILabel m_label;
	
	// configuration
	public int m_extinguisher;
	public int m_timer;
	
	// internal state
	private int m_score;
	private int m_displayed;
	
	public void Start ()
	{
		m_score = 0;
		m_displayed = 0;
		UpdateLabel();
	}
	
	public void Update ()
	{
		if( m_score == m_displayed ) {
			return;

		} else {
			// TODO: nice smooth tween
			m_displayed = m_score;
			UpdateLabel();
		}
	}
	
	public void AddScore(int score)
	{
		m_score += score;
	}
	
	public void SubstractScore(int score)
	{
		m_score -= score;
	}
	
	public void BonusScore(int score)
	{
		m_score += score;
	}
	
	private void UpdateLabel()
	{
		m_label.text = Mathf.RoundToInt( m_displayed ).ToString();
	}
}

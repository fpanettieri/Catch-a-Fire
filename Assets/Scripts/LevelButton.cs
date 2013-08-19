using UnityEngine;
using System.Collections;

public class LevelButton : MonoBehaviour
{
	// injected dependencies
	public UISprite m_lock;
	
	// configuration
	public bool m_forceUnlock;
	public string m_levelName;
	
	public void Start()
	{
		if(Unlocked()){
			UnlockLevel();
		} else {
			LockLevel();
		}
	}
	
	private bool Unlocked()
	{
		if( m_forceUnlock ){ return true; }
		if( PlayerPrefs.HasKey( m_levelName + "Unlocked" ) ){ return true; }
		return false;
	}
	
	private void LockLevel()
	{
		if(m_lock != null){	m_lock.enabled = true; }
		collider.enabled = false;
	}
	
	private void UnlockLevel()
	{
		if(m_lock != null){	m_lock.enabled = false; }
		collider.enabled = true;
	}
	
	public void OnClick ()
	{
		if (string.IsNullOrEmpty(m_levelName)){ return; }
		Application.LoadLevel(m_levelName);
	}
}

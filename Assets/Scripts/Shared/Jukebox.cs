using UnityEngine;
using System.Collections;

public class Jukebox : MonoBehaviour
{
	private static Jukebox instance;
	
	public AudioClip[] m_musics;
	
	public void Awake() 
    {
       if ( instance != null && instance != this ){
         Destroy( gameObject );
         return;
       } else { 
         instance = this;
       }
 
       DontDestroyOnLoad( gameObject );
    }
	
	public void Start()
	{
		OnLevelWasLoaded(Application.loadedLevel);
	}
 
	public void OnLevelWasLoaded(int _level)
    {
		if( _level >= m_musics.Length || m_musics[_level] == null ){ 
			Debug.LogWarning("Music for level " + _level + " not configured");
			return;
		}
		
		if( m_musics[_level] == audio.clip ){ return; }
		
		audio.Stop();
		audio.clip = m_musics[_level];
		audio.Play();
	}
}

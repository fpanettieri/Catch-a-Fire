using UnityEngine;
using System.Collections;

public class FakeLevel : MonoBehaviour
{
	public void Awake()
	{
		if( !PlayerPrefs.HasKey( "CurrentLevel" ) ){
			 PlayerPrefs.SetString( "CurrentLevel", "Level1" );	
		}
	}
}

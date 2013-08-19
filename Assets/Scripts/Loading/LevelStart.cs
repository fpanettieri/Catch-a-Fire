using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour
{
	public void OnClick()
	{
		Application.LoadLevel( PlayerPrefs.GetString( "CurrentLevel" ));
	}
}

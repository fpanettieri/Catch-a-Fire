using UnityEngine;
using System.Collections;

public class InitLang : MonoBehaviour
{
	public void Awake()
	{
		if(!PlayerPrefs.HasKey("Lang")){
			PlayerPrefs.SetString("Lang", "en");
		}
		
		Localization.instance.currentLanguage = PlayerPrefs.GetString("Lang");
	}
}

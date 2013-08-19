using UnityEngine;
using System.Collections;

public class LangSelector : MonoBehaviour
{
	// injected dependency
	private UILabel m_label;
	
	public void Awake()
	{
		m_label = GetComponent<UILabel>();
		
		if(!PlayerPrefs.HasKey("Lang")){
			PlayerPrefs.SetString("Lang", "en");
		} else {
			m_label.text = PlayerPrefs.GetString("Lang");
		}
		
		Localization.instance.currentLanguage = PlayerPrefs.GetString("Lang");
	}
	
	public void OnClick()
	{
		if(PlayerPrefs.GetString("Lang").Equals("en")){
			PlayerPrefs.SetString("Lang", "es");
		} else {
			PlayerPrefs.SetString("Lang", "en");
		}
		
		m_label.text = PlayerPrefs.GetString("Lang");
		Localization.instance.currentLanguage = PlayerPrefs.GetString("Lang");
	}
}

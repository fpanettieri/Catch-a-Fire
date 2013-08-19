using UnityEngine;
using System.Collections;

public class LangSelector : MonoBehaviour
{
	// injected dependency
	private UILabel m_label;
	
	public void Start()
	{
		m_label = GetComponent<UILabel>();
		m_label.text = PlayerPrefs.GetString("Lang");
		
	}
	
	public void OnClick()
	{
		SwitchLang();
		UpdateLabel();
	}
	
	private void SwitchLang()
	{
		if(PlayerPrefs.GetString("Lang").Equals("en")){
			PlayerPrefs.SetString("Lang", "es");
		} else {
			PlayerPrefs.SetString("Lang", "en");
		}
		Localization.instance.currentLanguage = PlayerPrefs.GetString("Lang");
	}
	
	private void UpdateLabel()
	{
		m_label.text = PlayerPrefs.GetString("Lang");
	}
}

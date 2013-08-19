using UnityEngine;
using System.Collections;

public class LangSelector : MonoBehaviour
{
	// injected dependency
	private UILabel m_label;
	
	public void Start()
	{
		if(!PlayerPrefs.HasKey("Lang")){
			PlayerPrefs.SetString("Lang", "EN");
		}
		m_label = GetComponent<UILabel>();
	}
	
	public void OnClick()
	{
		if(PlayerPrefs.GetString("Lang").Equals("EN")){
			PlayerPrefs.SetString("Lang", "ES");
		} else {
			PlayerPrefs.SetString("Lang", "EN");
		}
		m_label.text = PlayerPrefs.GetString("Lang");
	}
}

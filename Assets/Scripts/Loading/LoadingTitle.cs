using UnityEngine;
using System.Collections;

public class LoadingTitle : MonoBehaviour
{
	private UILabel m_label;
	
	public void Start()
	{
		m_label = GetComponent<UILabel>();
		OnLocalize(Localization.instance);
	}
	
	public void OnLocalize (Localization loc)
	{
		m_label.text = Localization.instance.Get("loading." + PlayerPrefs.GetString( "CurrentLevel" )  + ".title");
	}
}

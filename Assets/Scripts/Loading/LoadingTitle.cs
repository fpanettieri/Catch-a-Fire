using UnityEngine;
using System.Collections;

public class LoadingTitle : MonoBehaviour
{
	public void Start()
	{
		UILocalize localize = GetComponent<UILocalize>();
		localize.key = "loading." + PlayerPrefs.GetString( "CurrentLevel" )  + ".title";
		localize.OnLocalize(Localization.instance);
	}
}

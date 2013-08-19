using UnityEngine;
using System.Collections;

public class LoadingTip : MonoBehaviour
{
	public void Start()
	{
		UILocalize localize = GetComponent<UILocalize>();
		localize.key = "loading." + PlayerPrefs.GetString( "CurrentLevel" )  + ".tip";
		localize.OnLocalize(Localization.instance);
	}
}

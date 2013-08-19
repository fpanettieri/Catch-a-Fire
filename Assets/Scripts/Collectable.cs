using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{

	public void Start ()
	{
		transform.LookAt(Camera.main.transform);
		transform.Rotate(0, 180, 0);
	}
}

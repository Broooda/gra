using UnityEngine;
using System.Collections;

public class exitClick : MonoBehaviour {

	void OnMouseOver () {
		if(Input.GetMouseButtonDown(0))
		{

	Application.Quit();
		}
	}
}

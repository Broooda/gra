using UnityEngine;
using System.Collections;

public class onStartClick : MonoBehaviour {
	public Camera menu;
	public Camera loading;

	void Start(){
		menu.enabled = true;
		loading.enabled = false;
	}
	void OnMouseOver () {
		if(Input.GetMouseButtonDown(0))
		{
			menu.enabled = false;
			loading.enabled = true;
			Application.LoadLevel ("main"); 
		}
	}
}
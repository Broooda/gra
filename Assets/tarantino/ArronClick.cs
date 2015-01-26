using UnityEngine;
using System.Collections;

public class ArronClick : MonoBehaviour {
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			CameraManager.SelectCamera (0);
			GameObject.Find ("First Person Controller").SendMessage ("SetControllable", true);
            Screen.showCursor = false;
		}
	}
}

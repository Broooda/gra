using UnityEngine;
using System.Collections;

public class backC : MonoBehaviour {
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			CameraManager.SelectCamera (0);
		}
	}
}

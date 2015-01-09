using UnityEngine;
using System.Collections;

public class MonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "m";
			text.color = Color.white;
		}
	}
}

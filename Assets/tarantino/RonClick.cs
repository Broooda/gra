using UnityEngine;
using System.Collections;

public class RonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "r";
			text.color = Color.white;
		}
	}
}

using UnityEngine;
using System.Collections;

public class UonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "u";
			text.color = Color.white;
		}
	}
}

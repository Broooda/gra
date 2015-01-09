using UnityEngine;
using System.Collections;

public class OonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "o";
			text.color = Color.white;
		}
	}
}

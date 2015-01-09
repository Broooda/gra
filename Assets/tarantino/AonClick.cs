using UnityEngine;
using System.Collections;

public class AonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "a";
			text.color = Color.white;
		}
	}
}

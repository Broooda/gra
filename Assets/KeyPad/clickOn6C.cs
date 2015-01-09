using UnityEngine;
using System.Collections;

public class clickOn6C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "6";
			text.color = Color.black;
			}
	}
}

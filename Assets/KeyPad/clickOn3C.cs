using UnityEngine;
using System.Collections;

public class clickOn3C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "3";
			text.color = Color.black;
			}
	}
}

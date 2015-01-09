using UnityEngine;
using System.Collections;

public class clickOn2C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "2";
			text.color = Color.black;
			}
	}
}

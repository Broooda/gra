using UnityEngine;
using System.Collections;

public class clickOn7C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "7";
			text.color = Color.black;
			}
	}
}

using UnityEngine;
using System.Collections;

public class clickOn0C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "0";
			text.color = Color.black;
			}
	}
}

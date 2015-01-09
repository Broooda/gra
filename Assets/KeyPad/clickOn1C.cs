using UnityEngine;
using System.Collections;

public class clickOn1C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "1";
			text.color = Color.black;
			}
	}
}

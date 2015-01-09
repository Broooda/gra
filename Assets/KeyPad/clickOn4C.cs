using UnityEngine;
using System.Collections;

public class clickOn4C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "4";
			text.color = Color.black;
			}
	}
}

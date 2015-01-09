using UnityEngine;
using System.Collections;

public class clickOn9C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "9";
			text.color = Color.black;
			}
	}
}

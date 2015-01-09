using UnityEngine;
using System.Collections;

public class clickOn5C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "5";
			text.color = Color.black;
			}
	}
}

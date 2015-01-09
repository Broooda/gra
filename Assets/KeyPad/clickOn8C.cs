using UnityEngine;
using System.Collections;

public class clickOn8C : MonoBehaviour {
	public TextMesh text;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "8";
			text.color = Color.black;
			}
	}
}

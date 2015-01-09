using UnityEngine;
using System.Collections;

public class NonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "n";
			text.color = Color.white;
		}
	}
}

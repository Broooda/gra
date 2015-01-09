using UnityEngine;
using System.Collections;

public class EonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "e";
			text.color = Color.white;
		}
	}
}

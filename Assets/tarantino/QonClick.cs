using UnityEngine;
using System.Collections;

public class QonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "q";
			text.color = Color.white;
		}
	}
}

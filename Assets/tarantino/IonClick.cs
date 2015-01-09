using UnityEngine;
using System.Collections;

public class IonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "i";
			text.color = Color.white;
		}
	}
}

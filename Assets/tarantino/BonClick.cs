using UnityEngine;
using System.Collections;

public class BonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "b";
			text.color = Color.white;
		}
	}
}

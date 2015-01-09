using UnityEngine;
using System.Collections;

public class TonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text += "t";
			text.color = Color.white;
		}
	}
}

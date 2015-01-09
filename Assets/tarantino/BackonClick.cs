using UnityEngine;
using System.Collections;

public class BackonClick : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text = text.text.Substring(0, text.text.Length - 1);
			text.color = Color.white;
		}
	}
}

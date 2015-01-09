using UnityEngine;
using System.Collections;

public class cliclOnDelC : MonoBehaviour {
	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			text.text = "";
			text.color = Color.black;
		}
	}
}

using UnityEngine;
using System.Collections;

public class EnteronClickc : MonoBehaviour {

	public TextMesh text;
	
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			if(text.text == "tarantino"){
				text.color = Color.green;
				tarantinoCode.codeOk = true;
			}
			else
				text.color = Color.red;
		}
	}
}

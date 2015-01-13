using UnityEngine;
using System.Collections;

public class clickOnEnterC : MonoBehaviour {
	public TextMesh text;
	public AudioSource wrong;

	void Awake(){
		wrong = transform.Find("wrong_code").audio; //wrong_code to nazwa podobiektu do którego dodajesz audiosource
	}
	
	void OnMouseOver() {
				if (Input.GetMouseButtonDown (0)) {
						if (text.text == "2437") {
								text.color = Color.green;
								audio.Play();
								keyPad.ok=true;
						} else {
								text.color = Color.red;
								wrong.Play();
						}
				}
		}
}
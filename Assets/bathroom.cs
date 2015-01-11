using UnityEngine;
using System.Collections;

public class bathroom : MonoBehaviour {
	private bool param=false;
	private bool doorIsOpen=false;
	public int speedOpen=100;
	public AudioSource closed;
	
	void Update(){
		if (Input.GetKey (KeyCode.E) && param == true && hud.exists ("Czerwony klucz")) {
			if (transform.FindChild ("body").localEulerAngles.y < 90.0f) {
				transform.FindChild ("body").Rotate (Vector3.up * 0.04f * speedOpen);
			}
		}
		if (Input.GetKey (KeyCode.E) && param == true && !hud.exists ("Czerwony klucz")) {
			closed.Play ();
		}
		if(doorIsOpen){
			if(transform.FindChild("body").localEulerAngles.y > 2){
				transform.FindChild("body").Rotate(Vector3.down*0.02f*speedOpen);
			}
			else{
				doorIsOpen=false;
			}
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
		}
	}
	void OnTriggerExit(){
		doorIsOpen = true;
		param = false;
	}
}

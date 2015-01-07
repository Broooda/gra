using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	private bool param=false;
	private bool doorIsOpen=false;
	public int speedOpen=100;
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
			if(transform.FindChild("body").localEulerAngles.y < 90.0f){
				transform.FindChild("body").Rotate(Vector3.up*Time.deltaTime*speedOpen);
			}
		}
		if(doorIsOpen){
			if(transform.FindChild("body").localEulerAngles.y > 2){
				transform.FindChild("body").Rotate(Vector3.down*Time.deltaTime*speedOpen);
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

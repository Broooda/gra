using UnityEngine;
using System.Collections;

public class keyPad : MonoBehaviour {
	private bool param=false;
	
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
			GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
			CameraManager.SelectCamera (3);
		}
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
		}
	}
	void OnTriggerExit(){
		param = false;
	}
	
}

using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	private string name;
	private bool param=false;
	void Start(){
		name=gameObject.transform.name;
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.E) && param==true) {
			hud.addItem(name);
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
		}
	}
	void OnTriggerExit(){
		param=true;
	}
}

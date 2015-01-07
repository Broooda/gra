using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

	private bool param=false;
	void Update(){
		if (Input.GetKeyDown(KeyCode.E) && param==true) {
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
		}
	}
}

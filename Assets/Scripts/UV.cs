using UnityEngine;
using System.Collections;

public class UV : MonoBehaviour {
	private GameObject code;
	void Update(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 15)){
			if(hit.collider.gameObject.tag=="Code"){
				code= hit.collider.gameObject;
				code.SendMessage("CodeActive",true);
			}
		}
	}
}

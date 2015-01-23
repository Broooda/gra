using UnityEngine;
using System.Collections;

public class UV : MonoBehaviour {
	private GameObject code;
	private bool visible=false; 
	void Update(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 15)){
			if(hit.collider.gameObject.tag=="Code" && !visible){
				code= hit.collider.gameObject;
				code.SendMessage("CodeActive",true);
				visible=true;
			}
			else{
				if(visible){
					visible=false;
					code.SendMessage("CodeActive",false);
				}
			}
		}
	}
}

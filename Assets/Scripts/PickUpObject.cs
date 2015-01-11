using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	private string name;
	private bool param=false;
    private string button;
	void Start(){
		name=gameObject.transform.name;
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.E) && param==true) {
			hud.addItem(name);
            hud.showinfo = false;
			Destroy(gameObject);
            if (name.Equals("UV"))
            {
                button = "U";
            }
            else if (name.Equals("latarka"))
            {
                button = "F";
            }
            hud.displayMessage("Aby użyć: " + name + " wciśnij " + button);
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
		}
	}
	void OnTriggerExit(){
		param=false;
	}
}

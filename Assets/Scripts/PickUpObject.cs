using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	private string name;
	private bool param=false;
    private string button;
	private bool flash=false;

	void Start(){
		name=gameObject.transform.name;
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.E) && param==true) {
			if(name.Equals("szklanka")){
				hud.drink();
				Destroy(gameObject);
			}
			else{
				hud.addItem(name);
				hud.showinfo = false;
				Destroy(gameObject);
				if (name.Equals("UV"))
				{
					button = "U";
					flash=true;
				}
				else if (name.Equals("latarka"))
				{
					button = "F";
					flash=true;
				}
				else{
					hud.key();
				}
				if(flash){
					hud.displayMessage("Aby użyć: " + name + " wciśnij " + button);
					flash=false;
				}
			}
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


using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour {
	private bool param=false;
	private bool doorsAreOpen=false;
	private bool firstOpen=false;
	public int speedOpen=100;
	public GameObject zielony_klucz;
	// Use this for initialization
	void Start () {
		zielony_klucz.collider.enabled = false;
	}
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
			if(!firstOpen){
				GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
				CameraManager.SelectCamera (8); //przenosi do opisu gry na lodowce
				firstOpen=true;
			}
			if(transform.FindChild("Right").localEulerAngles.y > 5.0f ){
				transform.FindChild("Right").Rotate(Vector3.down*Time.deltaTime*speedOpen);
			}
			if(transform.FindChild("Right").localEulerAngles.y <= 5.0f ){
				if(zielony_klucz!=null){
					zielony_klucz.collider.enabled = true;
				}
			}
		}
		if(doorsAreOpen){
			if(transform.FindChild("Right").localEulerAngles.y < 75.0f){
				transform.FindChild("Right").Rotate(Vector3.up*Time.deltaTime*speedOpen);
			}
			else{
				doorsAreOpen=false;
			}
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
			hud.displayMessage("Nacisnij E by otworzyć: lodówka");
		}
	}
	void OnTriggerExit(){
		doorsAreOpen = true;
		param = false;
	}
}

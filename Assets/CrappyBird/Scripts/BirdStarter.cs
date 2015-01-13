using UnityEngine;
using System.Collections;

public class BirdStarter : MonoBehaviour
{
	private bool param;
	public static bool gameIsEnabled;
	public static bool isFirstTry = true;
	// Use this for initialization
	void Start () {
		param = false;
		gameIsEnabled = false;
	}
	void Update(){
		if (Input.GetKey (KeyCode.E) && param == true) {
			param = false;
			Application.LoadLevel("win");
						
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
			hud.displayMessage("Nacisnij E by podnieść wodę");
		}
	}
	void OnTriggerExit(){
		param = false;
	}
}

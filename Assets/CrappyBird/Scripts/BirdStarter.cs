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
						if (isFirstTry) {
								if (!gameIsEnabled) {
										GameObject.Find ("First Person Controller").SendMessage ("SetControllable", false);
										CameraManager.SelectCamera (6);
										gameIsEnabled = true;
					isFirstTry = false;
								}
			} else CameraManager.SelectCamera(7);
				}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
			hud.displayMessage("Nacisnij E by rozpocząć: minigra");
		}
	}
	void OnTriggerExit(){
		param = false;
	}
}

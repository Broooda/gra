using UnityEngine;
using System.Collections;

public class ShooterStarter : MonoBehaviour
{
	private bool param;
    public static bool gameIsEnabled;
	// Use this for initialization
	void Start () {
        param = false;
        gameIsEnabled = false;
	}
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
            param = false;
            if (!gameIsEnabled)
            {
                GameController.isNewStarted = false;
				GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
				CameraManager.SelectCamera (2);
                gameIsEnabled = true;
			}
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

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
				GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
				CameraManager.SelectCamera (7);//wlacza planze z opisem
                //gameIsEnabled = true;
			}
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

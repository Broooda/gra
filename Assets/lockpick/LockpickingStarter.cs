using UnityEngine;
using System.Collections;

public class LockpickingStarter : MonoBehaviour
{
	private bool param;
	public static bool lockpickIsEnabled;
	// Use this for initialization
	void Start () {
		param = false;
		lockpickIsEnabled = false;
	}
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
			param = false;
			if (!lockpickIsEnabled)
			{
				GameController.isNewStarted = false;
				GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
				CameraManager.SelectCamera (4);
				lockpickIsEnabled = true;
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

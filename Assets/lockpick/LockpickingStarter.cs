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
				GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
				CameraManager.SelectCamera (5);
				lockpickIsEnabled = true;
			}
		}
		/*if (Input.GetKeyDown(KeyCode.Escape) && param==true)
		{
			lockpickIsEnabled = false;
			GameObject.Find("First Person Controller").SendMessage("SetControllable",true);
			CameraManager.SelectCamera (0);
		}*/
		if (MotherScript.good == 5) {
			lockpickIsEnabled = false;
			GameObject.Find("First Person Controller").SendMessage("SetControllable",true);
			CameraManager.SelectCamera (0);
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

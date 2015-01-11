using UnityEngine;
using System.Collections;

public class BirdStarter : MonoBehaviour {

	private bool param;
	public static bool birdEnabled;
	// Use this for initialization
	void Start () {
		param = false;
		birdEnabled = false;
	}
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
			param = false;
			if (!birdEnabled)
			{
				GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
				CameraManager.SelectCamera (6);
				birdEnabled = true;
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

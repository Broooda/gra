using UnityEngine;
using System.Collections;

public class tarantinoCode : MonoBehaviour {
	private bool param=false;
	public static bool codeOk = false;
	public  AudioClip openSound;
	
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
			if(codeOk==false){
			GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
			CameraManager.SelectCamera (4);
			}
			else{
				if(transform.FindChild("Capsule02").localEulerAngles.z > 290.0f ){
					transform.FindChild("Capsule02").Rotate(Vector3.back*0.04f*70);
					audio.PlayOneShot(openSound);
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
		param = false;
	}

}

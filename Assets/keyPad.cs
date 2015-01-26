using UnityEngine;
using System.Collections;

public class keyPad : MonoBehaviour {
	private bool param=false;
	public static bool ok=false;
	private bool opened=false;
	private bool firstOpen=true;
	public AudioClip doorSound;
	
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true && ok==false) {
			GameObject.Find("First Person Controller").SendMessage("SetControllable",false);
			CameraManager.SelectCamera (3);
            Screen.showCursor = true;
		}
		if (param == true && ok == true && opened==false) {
				if(firstOpen){
					firstOpen=false;
					audio.PlayOneShot(doorSound);
				}
				transform.parent.Rotate (Vector3.up * 1 * 90);
				opened=true;
				}
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			param=true;
            hud.displayMessage("Nacisnij E by wpisać KOD");
		}
	}
	void OnTriggerExit(){
		param = false;
	}
	
}

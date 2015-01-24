using UnityEngine;
using System.Collections;

public class TigerRoom : MonoBehaviour {
	
	private bool doorIsOpen=false;
	private bool param=false;
	private bool firstOpen = true;
	public AudioClip TigerVoice;
	public AudioClip Comment;
	int speedOpen=100;
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true) {
			if(transform.FindChild("body").localEulerAngles.y < 10.0f){
				transform.FindChild("body").Rotate(Vector3.up*0.04f*speedOpen);
			}
			else{
				StartCoroutine("delay");
			}
		}
		if(doorIsOpen){
			if(transform.FindChild("body").localEulerAngles.y > 2.0f){
				transform.FindChild("body").Rotate(Vector3.down*0.02f*speedOpen);
			}
			else{
				doorIsOpen=false;
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
	void Tiger(){
		this.audio.PlayOneShot(TigerVoice);
	}
	IEnumerator delay(){
		Tiger();
		yield return new WaitForSeconds (0.2f);
		doorIsOpen=true;
		if(firstOpen==true){
			yield return new WaitForSeconds (2.1f);
			audio.PlayOneShot(Comment);
			firstOpen=false;
		}
	}

}

﻿using UnityEngine;
using System.Collections;

public class LockpickingStarter : MonoBehaviour
{
	private bool param;
	private bool won=false;
	public static bool lockpickIsEnabled;
	public AudioClip pick;
	// Use this for initialization
	void Start () {
		param = false;
		lockpickIsEnabled = false;
	}
	void Update(){
		if (Input.GetKey(KeyCode.E) && param==true && won==false) {
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
		if (MotherScript.good == 5 && won==false) {
			lockpickIsEnabled = false;
			GameObject.Find("First Person Controller").SendMessage("SetControllable",true);
			CameraManager.SelectCamera (0);
			hud.addItem("Srebrny klucz");
			audio.PlayOneShot(pick);
			won=true;
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

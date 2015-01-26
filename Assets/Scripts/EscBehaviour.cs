using UnityEngine;
using System.Collections;

public class EscBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale=1.0f;
			CameraManager.SelectCamera(0);
			GameObject.Find("First Person Controller").SendMessage("SetControllable",true);
		}
	
	}
}

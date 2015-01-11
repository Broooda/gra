using UnityEngine;
using System.Collections;

public class UVTrigger : MonoBehaviour {

	public static bool isOn;
	private Light flashlight;
	public float on = 3f;
	public float off = 0.0f;

    private float nextSwitch;
	// Use this for initialization
	void Start () {
		flashlight = transform.FindChild("UV_body").light;
		flashlight.intensity=off;
	}
	
	// Update is called once per frame
	void Update () {
		if(isOn==true){
			flashlight.intensity=on;
			isOn=false;
		}
	}
	public static void On(){
		isOn = true;
	}
}

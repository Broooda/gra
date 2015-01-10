using UnityEngine;
using System.Collections;

public class UVTrigger : MonoBehaviour {

	public bool isOn;
	private Light flashlight;
	public float on = 3f;
	public float off = 0.0f;
    public float switchingRate;

    private float nextSwitch;
	// Use this for initialization
	void Start () {
		flashlight = transform.FindChild("UV_body").light;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.U) && Time.time > nextSwitch)
        {
			if(isOn==true) isOn=false;
			else isOn=true;
		}
		if(isOn==true){
			flashlight.intensity=on;
		}
		if(isOn==false){
			flashlight.intensity=off;
		}
	}
}

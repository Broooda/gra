using UnityEngine;
using System.Collections;

public class LatarkaTrigger : MonoBehaviour
{
    public float highIntensity = 3f;
    public float lowIntensity = 0.0f;
    public float switchingRate;
	public static bool latarkaOn;

    private bool param = false;
    private bool latarkaIsOn = false;
    private Light latarka;
    private float nextSwitch;

    void Start()
    {
        latarka = transform.Find("latarka_body").light;
		latarka.intensity=lowIntensity;
    }

    void Update()
    {
		if(latarkaOn==true){
			latarka.intensity=highIntensity;
			latarkaOn=false;
		}
        /*if (Input.GetKey(KeyCode.F) && param == true && Time.time > nextSwitch)
        {
            if (latarka.intensity == lowIntensity)
            {
                latarka.intensity = highIntensity;
                nextSwitch = Time.time + switchingRate;
            }
            else
            {
                latarka.intensity = lowIntensity;
                nextSwitch = Time.time + switchingRate;
            }
        }*/

    }
    /*void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            param = true;
        }
    }
    void OnTriggerExit()
    {
        param = false;
    }*/
	public static void On(){
		latarkaOn = true;
	}
}

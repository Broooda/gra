using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static GameObject[] cameras;
	public GameObject cam1; // koniecznie MAIN CAMERA
	public GameObject cam2;
	public GameObject cam3;
	public GameObject cam4;
	public GameObject cam5;
	// Use this for initialization
	void Start () {
		cameras = new GameObject[4];
		cameras [0] = cam1;
		cameras [1] = cam2;
		cameras [2] = cam3;
		cameras [3] = cam4;
		cameras [4] = cam5;
		
        for (int i = 1; i < cameras.Length; i++) //na poczatku wylacza wszsytkie kamery oprocz glownej
        {
            cameras[i].active = false;
        }
            
	}
	// Update is called once per frame
	void Update () {
	
	}
	public static void SelectCamera(int index){
		AudioListener camListener;
		for(int i=0; i<cameras.Length;i++){
			camListener=cameras[i].GetComponent<AudioListener>();
			if(i==index){
				cameras[i].active=true;
				if(camListener.enabled==false){
					camListener.enabled=true;
				}
			}
			else{
				cameras[i].active=false;
				if(camListener.enabled==true){
					camListener.enabled=false;
				}
			}
		}
	}
}

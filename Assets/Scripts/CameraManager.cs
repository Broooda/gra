using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static GameObject[] cameras;
	public GameObject cam1;
	public GameObject cam2;
	public GameObject cam3;
	// Use this for initialization
	void Start () {
		cameras = new GameObject[3];
		cameras [0] = cam1;
		cameras [1] = cam2;
		cameras [2] = cam3;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public static void SelectCamera(int index){
		for(int i=0; i<cameras.Length;i++){
			if(i==index){
				cameras[i].camera.active=true;
			}
			else{
				cameras[i].camera.active=false;
			}
		}
	}
}

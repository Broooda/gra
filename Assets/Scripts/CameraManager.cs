using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static float counter=0;
	public static GameObject[] cameras;
    public GameObject cam1; // koniecznie MAIN CAMERA plansza poczatek glownej gry
	public GameObject cam2; //blocks
	public GameObject cam3; //shooter
	public GameObject cam4; //keypad
	public GameObject cam5; //keyboard
	public GameObject cam6; //lockpicking
	public GameObject cam7; //birdgame
    public GameObject cam8; //plansza shooter
    public GameObject cam9; //plansza lodowka
    public GameObject cam10; //plansza lockpicking
    public GameObject cam11; //plansza poczatek glownej gry
	public GameObject cam12; //plansza ESC pauza

	private float prevMouseX;
	private float prevMouseY;

	// Use this for initialization
	void Start () {
		cameras = new GameObject[12];
		cameras [0] = cam1;
		cameras [1] = cam2;
		cameras [2] = cam3;
		cameras [3] = cam4;
		cameras [4] = cam5;
		cameras [5] = cam6;
		cameras [6] = cam7;
        cameras [7] = cam8;
        cameras [8] = cam9;
        cameras [9] = cam10;
        cameras [10] = cam11;
		cameras [11] = cam12;
		
        for (int i = 0; i < cameras.Length; i++) //na poczatku wylacza wszsytkie kamery oprocz glownej
        {
            //cameras[i].active = false;
			cameras[i].SetActive(false);
        }
		cameras[10].SetActive(true);
		prevMouseX = MouseLook.sensitivityX;
		prevMouseY = MouseLook.sensitivityY;
            
	}
	// Update is called once per frame
	void Update () {
		if (cameras [0].activeSelf == true) {
			counter += Time.deltaTime*1.5f; //Time.deltaTime will increase the value with 1 every second.
			//Debug.Log(counter);
			MouseLook.sensitivityX=prevMouseX;
			MouseLook.sensitivityY=prevMouseY;
		} 
		else {
			MouseLook.sensitivityX=0;
			MouseLook.sensitivityY=0;
		}
	
	}
	public static void SelectCamera(int index){
		AudioListener camListener;
		for(int i=0; i<cameras.Length;i++){
			camListener=cameras[i].GetComponent<AudioListener>();
			if(i==index){
				//cameras[i].active=true;
				cameras[i].SetActive(true);
				if(camListener.enabled==false){
					camListener.enabled=true;
				}
			}
			else{
				//cameras[i].active=false;
				cameras[i].SetActive(false);
				if(camListener.enabled==true){
					camListener.enabled=false;
				}
			}
		}
	}
}

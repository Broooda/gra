using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		cameras = new GameObject[11];
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
		
        for (int i = 0; i < cameras.Length-1; i++) //na poczatku wylacza wszsytkie kamery oprocz glownej
        {
            //cameras[i].active = false;
			cameras[i].SetActive(false);
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

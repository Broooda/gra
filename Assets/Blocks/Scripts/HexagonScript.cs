using UnityEngine;
using System.Collections;

public class HexagonScript : MonoBehaviour {
	public bool isChosen;
	private int licznik;
	public GameObject laser;
	private GameObject localLaser;
	private Vector3 defaultRot;
	public static int connection=0;
	public bool end;
	private bool check=false;
	private bool check2=false;
	public static bool flag;
	public AudioClip off;
	Sprite select;
	Sprite unselect;
	
	void Start(){
		if(!end){
			select=Resources.Load("Textures/hexagon_selected", typeof(Sprite)) as Sprite;
			unselect=Resources.Load("Textures/hexagon_unselected", typeof(Sprite)) as Sprite;
			defaultRot = transform.eulerAngles; 
			licznik = 1;
		}
	}
	void OnMouseDown() {
		if(!end){
			if(licznik==1){
				isChosen=true;
				GetComponent<SpriteRenderer>().sprite = select;
				transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, 10);
				ShowLaser();
				check2=false;
			}
			if(licznik==2){
				isChosen=false;
				GetComponent<SpriteRenderer>().sprite = unselect;
			}
			if(licznik==3){
				GameObject.Destroy(localLaser);
				this.audio.PlayOneShot(off);
				if(check==true && check2==false){
					Subtract();
					check=false;
				}
			}
			licznik++;
			if(licznik>3){
				licznik=1;
			}
		}
	}
	void ShowLaser(){
		Vector3 fwd = new Vector3 ();
		fwd.Set (1f, 0f,0f);
		fwd += transform.position;
		localLaser= Instantiate(laser,fwd,transform.rotation) as GameObject;
		Transform t = localLaser.transform;
		t.parent = transform;
	}
	void Update(){
		if(!end){
			if(isChosen){
				if(Input.GetKey(KeyCode.A)) {
					transform.Rotate (0,0, 1);
				}
				if(Input.GetKey(KeyCode.D)) {
					transform.Rotate (0,0, -1);
				}
			}
		}
	}
	void Add(){
		connection++;
		check = true;
	}
	void Subtract(){
		connection--;
		check2 = true;
	}
	bool CheckEnd(){
		return end;
	}
	void SetFlag(){
		if(end){
			flag = true;
			LaserScript.endFlagHexagon=true; 
		}
	}
	void LossFlag(){
		flag = false;
	}
}

using UnityEngine;
using System.Collections;

public class SquareScript : MonoBehaviour {
	public bool isChosen;
	private int licznik;
	public GameObject laser;
	private GameObject localLaser;
	private Vector3 defaultRot;
	public static int connection=0;
	public static bool flag;
	public bool end;
	private int check=0;
	private int check2=0;
	public AudioClip off;
	Sprite select;
	Sprite unselect;
	public static bool gameOver=false;
	private bool endIsHit=false;
	private bool hit=false;
	private GameObject whatIsHit;

	
	void Start(){
		if(!end){
			select=Resources.Load("Textures/square_selected", typeof(Sprite)) as Sprite;
			unselect=Resources.Load("Textures/square_unselected", typeof(Sprite)) as Sprite;
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
				check=0;
				check2=0;
			}
			if(licznik==2){
				isChosen=false;
				GetComponent<SpriteRenderer>().sprite = unselect;
			}
			if(licznik==3){
				GameObject.Destroy(localLaser);
				this.audio.PlayOneShot(off);
				if(check>check2){
					if(endIsHit){
						flag=false;
						endIsHit=false;
					}
					if(whatIsHit!=null){ 
						if(whatIsHit.GetComponent<SquareScript>().IsHit()){
							whatIsHit.GetComponent<SquareScript>().NowHit();
						}//ISHIT można jeszcze sprawdzić jakby był jakiś bug
					}
					Subtract();
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
		fwd.Set (1.1f, 0f,0f);
		fwd += transform.position;
		localLaser= Instantiate(laser,fwd,transform.rotation) as GameObject;
		Transform t = localLaser.transform;
		t.parent = transform;
	}
	void Update(){
		if(!end){
			if(isChosen && !gameOver){
				if(Input.GetKey(KeyCode.A)) {
					transform.Rotate (0,0, 1);
				}
				if(Input.GetKey(KeyCode.D)) {
					transform.Rotate (0,0, -1);
				}
			}
		}
	}
	void Add(GameObject id){
		whatIsHit = id;
		connection++;
		check++;
	}
	void Subtract(){
		whatIsHit = null;
		if(connection>0){
			connection--;
			check2++;
		}
	}
	void SetFlag(){
		if(end){
			if(!flag){
				flag = true;
				LaserScript.nowSquare=true;
				LaserScript.endFlagSquare=true; 
			}
		}
	}
	void LossFlag(){
		if(flag){
			if(endIsHit){
				flag=false;
				endIsHit=false;
			}
		}
	}
	void HitEnd(){
		endIsHit = true;
	}
	public bool IsHit(){
		return hit;
	}
	public void NowHit(){
		if(hit) hit=false;
		else hit = true;
	}
}

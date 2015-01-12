using UnityEngine;
using System.Collections;

public class hud : MonoBehaviour {

	public Texture myBoxTexture;
	public Texture zielony_klucz;
	public Texture niebieski_klucz;
	public Texture czerwony_klucz;
	public Texture zloty_klucz;
	public Texture srebrny_klucz;
	public Texture latarka;
	public Texture latarkauv;
	public Texture water;
	public GameObject uvobject;
	private GameObject uvlocal;
	private static bool UVIn;
	public GameObject latarkaobject;
	private GameObject latarkalocal;
	private static bool LatarkaIn;

	public static float barDisplay;
	public static float thirst;

	public static string whatitem;
	public static bool showinfo;

	public static string message;
	public static bool showmessage;

	public Texture line;
	private int boxWidth= 140;
	private int boxPosition= 0;
	private static Hashtable allitems = new Hashtable();
	private static Hashtable myitems = new Hashtable();
	private float nextSwitch;
	private bool UVOn = false;
    private bool LatarkaOn = false;
    private Vector3 fwd;

	void Start(){
		allitems.Add ("Zielony klucz", zielony_klucz);
		allitems.Add ("Niebieski klucz", niebieski_klucz);
		allitems.Add ("Czerwony klucz", czerwony_klucz);
		allitems.Add ("Zloty klucz", zloty_klucz);
		allitems.Add ("Srebrny klucz", srebrny_klucz);
		allitems.Add ("latarka", latarka);
		allitems.Add ("UV", latarkauv);

		myitems.Add ("Zielony klucz", zielony_klucz);
		myitems.Add ("Niebieski klucz", niebieski_klucz);
		myitems.Add ("Czerwony klucz", czerwony_klucz);
		myitems.Add ("Zloty klucz", zloty_klucz);
		myitems.Add ("Srebrny klucz", srebrny_klucz);

		thirst = 190;
        fwd = new Vector3();
	}

	void Update(){
		hud.barDisplay = Time.time*10;
		if (showmessage) {
			StartCoroutine(wait());
				}
		if(Input.GetKey(KeyCode.U) && UVIn==true && Time.time > nextSwitch){
            if (!UVOn && !LatarkaOn)
            {
				addUV();
                UVOn = true; ;
			}
            else if (!UVOn && LatarkaOn)
            {
                addUV();
                UVOn = true;

                GameObject.Destroy(latarkalocal);
                LatarkaOn = false;
            }
			else{
                UVOn = false;
				GameObject.Destroy(uvlocal);
			}
			nextSwitch=Time.time+0.2f;
		}
		if(Input.GetKey(KeyCode.F) && LatarkaIn==true && Time.time > nextSwitch){
            if (!LatarkaOn && !UVOn)
            {
                addFlashlight();
                LatarkaOn = true; ;
            }
            else if (!LatarkaOn && UVOn)
            {
                addFlashlight();
                LatarkaOn = true;

                GameObject.Destroy(uvlocal);
                UVOn = false;
            }
            else
            {
                LatarkaOn = false;
                GameObject.Destroy(latarkalocal);
            }
			nextSwitch=Time.time+0.2f;
		}
	}

	void OnGUI(){	
		GUI.Box(new Rect(boxPosition,Screen.height-100,Screen.width,100), myBoxTexture);

		GUI.Box(new Rect(Screen.width/2-120,Screen.height-120,240,20), myBoxTexture);

	
		if (thirst- barDisplay > 5) {
			GUI.DrawTexture(new Rect (Screen.width / 2 - 120, Screen.height - 120, thirst - barDisplay, 20), water, ScaleMode.StretchToFill, true, 0);
				} else {
			//TUTAJ GAME OVER !!!
			//TUTAJ GAME OVER !!!
			//TUTAJ GAME OVER !!!
			//TUTAJ GAME OVER !!!
			GUI.Box (new Rect (Screen.width / 2 - 120, Screen.height - 120, 1, 20), water);
				}
		GUI.Label (new Rect(Screen.width/2-80,Screen.height-120,190,20),"pragnienie");
		int iter = 0;
		foreach(DictionaryEntry entry in myitems){
			GUI.DrawTexture(new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2),Screen.height-90,50,90), (Texture)entry.Value, ScaleMode.StretchToFill, true, 0);
			GUI.Label (new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2),Screen.height-95,200,80),(iter+1).ToString());
			GUI.Label (new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2)-5,Screen.height-20,200,80),entry.Key.ToString());
			GUI.DrawTexture(new Rect((boxPosition+(iter*boxWidth))+boxWidth,Screen.height-100,6,100), line);
			iter = iter+1;
		}
		if(showinfo)
		{
		    GUI.Label (new Rect(Screen.width/2,Screen.height-200,210,80),"Wcisnij klawisz 'E' by podniesc "+whatitem);
		}
		if (showmessage)
        {
			GUI.Label (new Rect(Screen.width/2,Screen.height-200,210,80),message);
		}

	}

	public static void showText(string txt){
		hud.showinfo = true;
		hud.whatitem = txt;
		}

	IEnumerator wait(){
		showmessage=true;
		yield return new WaitForSeconds (3.0f);
		showmessage=false;
		}

	public static bool exists(string s){
		return myitems.ContainsKey (s);
	}
	public static void addItem(string s){
		myitems.Add (s, allitems[s]);
		if(s=="UV"){
			UVIn=true;
		}
		if(s=="latarka"){
			LatarkaIn=true;
		}
	}
	public static void displayMessage(string txt){
		showmessage = true;
		message = txt;
	}
	public static void drink(){
		if (thirst-barDisplay + 20 < 240) {
						thirst += 20;
				}
	}
	public void addUV(){
		fwd.Set (0f, 0f,0f);
		fwd += transform.position;
		uvlocal= Instantiate(uvobject,fwd,transform.rotation) as GameObject;
		Transform t = uvlocal.transform;
		t.parent = transform;
		UVTrigger.On ();
	}
	public void addFlashlight(){
		fwd.Set (0f, 0f,0f);
		fwd += transform.position;
		latarkalocal= Instantiate(latarkaobject,fwd,transform.rotation) as GameObject;
		Transform t = latarkalocal.transform;
		t.parent = transform;
		LatarkaTrigger.On ();
	}
}

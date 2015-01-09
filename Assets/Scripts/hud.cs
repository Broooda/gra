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

	public Texture line;
	private int boxWidth= 140;
	private int boxPosition= 0;
	private static Hashtable allitems = new Hashtable();
	private static Hashtable myitems = new Hashtable();

	void Start(){
		allitems.Add ("Zielony klucz", zielony_klucz);
		allitems.Add ("Niebieski klucz", niebieski_klucz);
		allitems.Add ("Czerwony klucz", czerwony_klucz);
		allitems.Add ("Zloty klucz", zloty_klucz);
		allitems.Add ("Srebrny klucz", srebrny_klucz);
		allitems.Add ("Latarka", latarka);
		allitems.Add ("UV", latarkauv);
	}

	void OnGUI(){	

		GUI.Box(new Rect(boxPosition,Screen.height-100,Screen.width,100), myBoxTexture);
		int iter = 0;
		foreach(DictionaryEntry entry in myitems){
			GUI.DrawTexture(new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2),Screen.height-90,50,90), (Texture)entry.Value, ScaleMode.StretchToFill, true, 0);
			GUI.Label (new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2),Screen.height-95,200,80),(iter+1).ToString());
			GUI.Label (new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2)-5,Screen.height-20,200,80),entry.Key.ToString());
			GUI.DrawTexture(new Rect((boxPosition+(iter*boxWidth))+boxWidth,Screen.height-100,6,100), line);
			iter = iter+1;
		}
	}

	public static void addItem(string s){
		myitems.Add (s, allitems[s]);
	}
}

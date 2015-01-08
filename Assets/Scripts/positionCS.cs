using UnityEngine;
using System.Collections;

public class positionCS : MonoBehaviour {

	public Texture myBoxTexture;
	public Texture aTexture;
	public Texture line;
	private int boxWidth= 140;
	private int boxPosition= 0;
	private string[] itanz = new string[] {"łom", "latarka"};

	void OnGUI(){	
		GUI.Box(new Rect(boxPosition,Screen.height-100,Screen.width,100), myBoxTexture);
		int iter = 0;
		foreach(string value in itanz){
			GUI.DrawTexture(new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2),Screen.height-90,50,90), aTexture, ScaleMode.StretchToFill, true, 0);
			GUI.Label (new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2),Screen.height-95,200,80),(iter+1).ToString());
			GUI.Label (new Rect(((boxPosition+(iter*boxWidth))+boxWidth/2)-5,Screen.height-20,200,80),value);
			GUI.DrawTexture(new Rect((boxPosition+(iter*boxWidth))+boxWidth,Screen.height-100,6,100), line);

			iter = iter+1;
		}
	}
}

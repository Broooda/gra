using UnityEngine;
using System.Collections;

public class MainGameScript : MonoBehaviour {
	public GUIText winText;
	void Start () {
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(HexagonScript.connection>=4 && HexagonScript.flag==true && 
		   SquareScript.connection>=4 && SquareScript.flag==true && 
		   CircleScript.connection>=4 && CircleScript.flag==true){
				winText.text="WYGRANA!";
			CameraManager.SelectCamera (0);
		}
	}
}

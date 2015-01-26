using UnityEngine;
using System.Collections;

public class MainGameScript : MonoBehaviour {
	public TextMesh winText;
	public static bool BlockWin=false;
	void Start () {
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(HexagonScript.connection>=4 && HexagonScript.flag==true && 
		   SquareScript.connection>=4 && SquareScript.flag==true && 
		   CircleScript.connection>=4 && CircleScript.flag==true){
			StartCoroutine("delay");
		}
	}
	IEnumerator delay(){
		winText.text="WYGRANA!";
		yield return new WaitForSeconds (2);
		CameraManager.SelectCamera (0);
        Screen.showCursor = false;
		GameObject.Find ("First Person Controller").SendMessage ("SetControllable", true);
		BlockWin = true;
		winText.text = "";
		HexagonScript.gameOver = true;
		CircleScript.gameOver = true;
		SquareScript.gameOver = true;
	}
}

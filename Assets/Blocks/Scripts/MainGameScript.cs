using UnityEngine;
using System.Collections;

public class MainGameScript : MonoBehaviour {
	public TextMesh winText;
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
		GameObject.Find ("First Person Controller").SendMessage ("SetControllable", true);
		winText.text = "";
	}
}

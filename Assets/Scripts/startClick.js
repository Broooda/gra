#pragma strict


function OnMouseOver () {
	if(Input.GetMouseButtonDown(0))
	{
		Debug.Log("weszlem");
		Application.LoadLevel("main");
	}
}
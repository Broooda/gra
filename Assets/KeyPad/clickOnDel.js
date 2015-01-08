#pragma strict


function OnMouseOver () {
	if(Input.GetMouseButtonDown(0))
	{
		codeInput.code = "";
		codeInput.good = -1;
	}
}
#pragma strict

function OnMouseOver() {

	if(Input.GetMouseButtonDown(0))
	{
		codeInput.code = codeInput.code+"1";
		codeInput.good = -1;
	}
}
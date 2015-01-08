#pragma strict

function OnMouseOver() {
	if(Input.GetMouseButtonDown(0))
	{
		codeInput.code = codeInput.code+"9";
		codeInput.good = -1;
	}
}
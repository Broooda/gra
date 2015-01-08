#pragma strict

static var code;
static var good = -1;


function Update () {

	guiText.text = code;
	if (good == 1)
		guiText.color = Color.green;
	else if (good == 0)
		guiText.color = Color.red;
	else 
		guiText.color = Color.black;
}
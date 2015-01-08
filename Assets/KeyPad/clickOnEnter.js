
var wrong : AudioSource;
function Awake(){
    wrong = transform.Find("wrong_code").audio; //wrong_code to nazwa podobiektu do którego dodajesz audiosource
}

function OnMouseOver() {
	if(Input.GetMouseButtonDown(0))
	{
		if(codeInput.code == "5691")
		{
			codeInput.good = 1;
			audio.Play();
			GameObject.Find("Camera").SendMessage("SelectCamera",0);
		}
		else{
		    codeInput.good = 0;
		    wrong.Play();
		    GameObject.Find("Camera").SendMessage("SelectCamera",0);
		}
	}
}
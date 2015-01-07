#pragma strict

var hinge : MotherScript;
hinge = gameObject.GetComponent(MotherScript);

var mee : int;
var open : float;
var range :float = 0.2;
var flag : int = 0;
static var done : boolean = false;
static var me : int ;

function Start(){
	open = Random.Range(0.50,1.80);
	Debug.Log("Radom="+open);
	//me=mee;
	Debug.Log("me"+me);
}

function Update(){
	if(done==false){
		if(transform.position.y > open-range){
			Debug.Log("ja:"+me+"tutaj");
				if(flag==0){
					audio.Play();
					flag++;
					MotherScript.good++;
					//done=true;
				}
				rigidbody2D.mass=10000;
				rigidbody2D.gravityScale=0;
			//}
			//else{
			//	MotherScript.reset=true;
			//}
		}
	}
	if(MotherScript.reset==true){
		//flag==0;
		rigidbody2D.mass=2;
		rigidbody2D.gravityScale=1;
		done=false;
	}
}
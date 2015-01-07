#pragma strict

var hinge : MotherScript;
hinge = gameObject.GetComponent(MotherScript);

var open : float;
var range :float = 0.2;
var flag : int = 0;
var done : boolean = false;
var me : int;

function Start(){
	open = Random.Range(0.50,1.80);
}

function Update(){
	if(done==false){
		if(transform.position.y > open-range){
			if(me==MotherScript.now){
				Debug.Log("ruszasz"+me);
				if(flag==0){
					audio.Play();
					flag++;
					MotherScript.good++;
					done=true;
				}
				rigidbody2D.mass=10000;
				rigidbody2D.gravityScale=0;
			}
		/*	else{
				MotherScript.reset=true;
				Debug.Log("Czy ja tu wchodze");
						flag=0;
						rigidbody2D.mass=2;
						rigidbody2D.gravityScale=1;
						done=false;
			}*/
		}
	}
	//if(done==true){			Debug.Log("Czy ja tu wchodze");
	//	if(me!=MotherScript.now){
	//		MotherScript.reset=true;
	//		flag--;
	//	}
		
	//}
	
}

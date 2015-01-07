#pragma strict

var hinge : MotherScript;
hinge = gameObject.GetComponent(MotherScript);

var open : float;
var range :float = 0.2;
var flag : int = 0;
var me : int;
var originalPosition : Vector3;
var originalMass : int;
var orginalGravity : int;

function Start(){
	originalPosition = gameObject.transform.position;
	originalMass = gameObject.rigidbody2D.mass;
	orginalGravity = gameObject.rigidbody2D.gravityScale;
	open = Random.Range(0.50,1.80);
}

function Update(){
	if(MotherScript.whichDone[me-1]==true){
		rigidbody2D.isKinematic=true;
	}
	if(MotherScript.whichDone[me-1]==false){
		flag=0;
		rigidbody2D.isKinematic=false;
	}

	if(MotherScript.whichDone[me-1]==false){
		if(transform.position.y > open-range){
			if(me==MotherScript.now){
				//Debug.Log("ruszasz"+me);
				if(flag==0){
					audio.Play();
					flag++;
					MotherScript.good++;
					MotherScript.whichDone[me-1]=true;
					//Debug.Log("WLAZLA DO FLAGI "+me);	
				}
			}
			if(me!=MotherScript.now){
				for (var i = 0; i < MotherScript.whichDone.length; ++i) { MotherScript.whichDone[i] = false; }
				MotherScript.good=0;
				//Debug.Log("UZYJ INNEJ !!!");
			}
		}
	}
}

function toStart(){
	gameObject.rigidbody2D.mass = originalMass;
	gameObject.rigidbody2D.gravityScale = orginalGravity;
	flag=0;
	MotherScript.good=0;
	MotherScript.whichDone[me-1]=false;
}


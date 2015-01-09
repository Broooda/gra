using UnityEngine;
using System.Collections;

public class CheckScript : MonoBehaviour {

	float open;
	float range = 0;//0.2f;
	int flag = 0;
	public int me;
	Vector3 originalPosition;
	public float originalMass;
	public float orginalGravity;
	
	void  Start (){
		originalPosition = gameObject.transform.position;
		originalMass = gameObject.rigidbody2D.mass;
		orginalGravity = gameObject.rigidbody2D.gravityScale;
		open = Random.Range(0.70f,1.70f);
	}
	void  Update (){
		if(MotherScript.whichDone[me-1]==true){
			rigidbody2D.isKinematic=true;
			//Debug.Log("true "+me);
		}
		if(MotherScript.whichDone[me-1]==false){
			flag=0;
			rigidbody2D.isKinematic=false;
			//Debug.Log("false "+me);
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
					for (int i= 0; i < MotherScript.whichDone.Length; ++i) { MotherScript.whichDone[i] = false; }
					MotherScript.good=0;
					//Debug.Log("UZYJ INNEJ !!!");
				}
			}
		}
	}
	
	void  toStart (){
		gameObject.rigidbody2D.mass = originalMass;
		gameObject.rigidbody2D.gravityScale = orginalGravity;
		flag=0;
		MotherScript.good=0;
		MotherScript.whichDone[me-1]=false;
	}
	
}
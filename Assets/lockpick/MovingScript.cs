
using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {
	
	
	
	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	float speed = 5;
	
	
	void  Update (){
		if(LockpickingStarter.lockpickIsEnabled==true){
			if(Input.GetKey(moveUp)){
				rigidbody2D.velocity = new Vector2(0,speed);
			}
			else if(Input.GetKey(moveDown)){
				rigidbody2D.velocity = new Vector2(0,speed * -1);
			}
			else if(Input.GetKey(moveLeft)){
				rigidbody2D.velocity = new Vector2(speed * -1,0);
			}
			else if(Input.GetKey(moveRight)){
				rigidbody2D.velocity = new Vector2(speed,0);
			}
			else {
				rigidbody2D.velocity = new Vector2(0,0);
			}
		}
	}
}
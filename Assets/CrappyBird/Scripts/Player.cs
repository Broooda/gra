using UnityEngine;

public class Player : MonoBehaviour
{
	
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 jumpForce = new Vector2(0, 300);
	// Update is called once per frame
	private Vector3 initialPos;
	private Quaternion initialRotation;


	void Start(){

				initialPos = transform.position;
				initialRotation = transform.rotation;
		}

	void Update ()
	{ if(BirdStarter.gameIsEnabled == true){
		// Jump
		if (started ()) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce (jumpForce);
		}
		
		// Die by being off screen
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0) {
				Die ();
		}
	}
	
	}
	// Die by collision
	void OnCollisionEnter2D(Collision2D coll)
	{
				if (BirdStarter.gameIsEnabled == true) {
						if (coll.gameObject.tag == "Finish") {
				Die();
						} else
				Die ();
				}
		}
	void Die()
	{	

		transform.rotation = initialRotation;
		transform.position = initialPos;
		rigidbody2D.Sleep ();
		Generate.score = 0;
		CameraManager.SelectCamera (0);
		BirdStarter.gameIsEnabled = false;
		GameObject.Find ("First Person Controller").SendMessage ("SetControllable", true);

	}

	bool started()
	{
		if (BirdStarter.gameIsEnabled == true && Input.GetKeyUp ("space")) 
		{
			return true;
			
		} else {
			return false;
		}
	}

	
}
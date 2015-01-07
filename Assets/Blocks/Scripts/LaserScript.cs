using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
	[Header("Laser pieces")]
	public GameObject laserStart;
	public GameObject laserMiddle;
	public GameObject laserEnd;
	private GameObject start;
	private GameObject middle;
	private int counter=0;
	private bool square;
	private bool circle;
	private bool hexagon;
	public static bool endFlagCircle=false;
	public static bool endFlagHexagon=false;
	public static bool endFlagSquare=false;


	void Update()
	{
		// Create the laser start from the prefab
		if (start == null)
		{
			start = Instantiate(laserStart) as GameObject;
			start.transform.parent = this.transform;
			start.transform.localPosition = Vector2.zero;
		}
		
		// Laser middle
		if (middle == null)
		{
			middle = Instantiate(laserMiddle) as GameObject;
			middle.transform.parent = this.transform;
			middle.transform.localPosition = Vector2.zero;
		}
		
		// Define an "infinite" size, not too big but enough to go off screen
		float maxLaserSize = 3;
		float currentLaserSize = maxLaserSize;
		
		// Raycast at the right as our sprite has been design for that
		Vector2 laserDirection = this.transform.right;
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position, laserDirection, maxLaserSize);
		
		if (hit.collider != null)
		{
			// We touched something!
			if(counter<=0) counter=1;
			else counter=2;
			// -- Get the laser length
			currentLaserSize = Vector2.Distance(hit.point, this.transform.position);
		}
		else
		{
			// Nothing hit
			if(counter>0) counter=0;
			else counter=-1;
		}
		if(counter==1 || counter==0){
			WhatIsHit(hit);
		}
		// Place things
		// -- Gather some data
		float startSpriteWidth = start.renderer.bounds.size.x;
		
		middle.transform.localScale = new Vector3 (currentLaserSize - startSpriteWidth, middle.transform.localScale.y, middle.transform.localScale.z);
		middle.transform.localPosition = new Vector2((currentLaserSize/2.1f), 0f);
	}
	void WhatIsHit(RaycastHit2D hit){
		if(counter==1){
			if(hit.collider.gameObject.tag=="square" && this.transform.parent.gameObject.tag=="square"){
				hit.collider.gameObject.SendMessage("SetFlag");
				this.transform.parent.gameObject.SendMessage("Add");
				square=true;
			}
			if(hit.collider.gameObject.tag=="circle" && this.transform.parent.gameObject.tag=="circle"){
				//hit.collider.gameObject.SendMessage("Add");
				hit.collider.gameObject.SendMessage("SetFlag");
				this.transform.parent.gameObject.SendMessage("Add");
				circle=true;
			}
			if(hit.collider.gameObject.tag=="hexagon" && this.transform.parent.gameObject.tag=="hexagon"){
				//hit.collider.gameObject.SendMessage("Add");
				hit.collider.gameObject.SendMessage("SetFlag");
				this.transform.parent.gameObject.SendMessage("Add");
				hexagon=true;
			}
		}
		else{
			if(square){
				if(endFlagSquare){
					this.transform.parent.gameObject.SendMessage("LossFlag");
					endFlagSquare=false;
				}
				this.transform.parent.gameObject.SendMessage("Subtract");
				square=false;
			}
			if(circle){
				if(endFlagCircle){
					this.transform.parent.gameObject.SendMessage("LossFlag");
					endFlagCircle=false;
				}
				this.transform.parent.gameObject.SendMessage("Subtract");
				circle=false;
			}
			if(hexagon){
				if(endFlagHexagon){
					this.transform.parent.gameObject.SendMessage("LossFlag");
					endFlagHexagon=false;
				}
				this.transform.parent.gameObject.SendMessage("Subtract");
				hexagon=false;
			}
		}
	}
}
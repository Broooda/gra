using UnityEngine;

public class Generate : MonoBehaviour
{
	public GameObject rocks;
	public GameObject water;
	int score = 0;
	bool once = false;
	// Use this for initialization
	void Start()
	{	
		if(BirdStarter.birdEnabled == true)
		InvokeRepeating("CreateObstacle", 1f, 1.5f);
		else return;
	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		if (BirdStarter.birdEnabled == true) {
						GUI.color = Color.black;
						GUILayout.Label (" Score: " + score.ToString ());
				} else
						return;
		}
	
	void CreateObstacle()
	{
		if (score < 5) {
						Instantiate (rocks);
						score++;
				} else if (once == false) {
			once = true;
			Instantiate(water);


				}
	}
	
}
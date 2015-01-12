using UnityEngine;

public class Generate : MonoBehaviour
{
	public GameObject rocks;
	public GameObject water;
	public static int score = 0;
	private bool once = false;
	// Use this for initialization
	void Start()
	{
		//InvokeRepeating ("CreateObstacle", 1f, 1.5f);
				
	}
	void Update()
	{
		if (started ()) {
						CreateObstacle ();
				}
		}

	// Update is called once per frame
	/*void OnGUI () 
	{
				//if (BirdStarter.gameIsEnabled == true) {
						GUI.color = Color.black;
						GUILayout.Label (" Score: " + score.ToString ());
				//}
		}*/
	void CreateObstacle()
	{
		if (score < 10) {
						Instantiate (rocks);
						score++;
				} else if (once == false) {
			once = true;
			Instantiate(water);


				}
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
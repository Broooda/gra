using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject ship;
    public GameObject enemyShip;
    public GameObject parentObject;
    public Vector3 spawnValues;
    public int hazardCount;
    public int waveHazardCount;
    public int waveEnemyShipCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private bool startCoroutine;
    public static bool isNewStarted;

    void Start()
    {
        startCoroutine = false;
        isNewStarted = false;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
    }

    void Update()
    {
        if (ShooterStarter.gameIsEnabled)
        {
            gameOverText.text = "";
            if ((ShooterStarter.gameIsEnabled) && !isNewStarted) 
            {
                this.audio.Play();
                enemyShip.audio.mute = false;
                CameraManager.SelectCamera(2);
                startCoroutine = true;
            }
            isNewStarted = true;
        }
        if (startCoroutine)
        {
            StartCoroutine(SpawnWaves());
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves()
    {
        startCoroutine = false;

        Vector3 spawnPositionship = new Vector3(0f,0f,0f);
        spawnPositionship += parentObject.transform.position;
        Quaternion spawnRotationship = Quaternion.identity;
        GameObject localship = Instantiate(ship, spawnPositionship, spawnRotationship) as GameObject;
        localship.transform.parent = parentObject.transform;

        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < waveHazardCount; i++)
        {
            for (int j = 0; j < hazardCount; j++)
            {
                Vector3 spawnPosition = new Vector3(Random.RandomRange(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                spawnPosition += parentObject.transform.position;
                Quaternion spawnRotation = Quaternion.identity;
                
                GameObject local = Instantiate(hazard, spawnPosition, spawnRotation) as GameObject;
                local.transform.parent = parentObject.transform;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                //isNewStarted = false;
                gameOver = false;
                yield break;
            }
        }
        for (int i = 0; i < waveEnemyShipCount; i++)
        {
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                //isNewStarted = false;
                gameOver = false;
                yield break;
            }
            Vector3 spawnPosition = new Vector3(Random.RandomRange(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            spawnPosition += parentObject.transform.position;
            GameObject local = Instantiate(enemyShip, spawnPosition, enemyShip.transform.rotation) as GameObject;
            local.transform.parent = parentObject.transform;
            yield return new WaitForSeconds(waveWait);
        }
        if (!gameOver)
        {
            gameOverText.text = "You Won";
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
        this.audio.Stop();
        CameraManager.SelectCamera(0);//chwilowo******************************
        GameObject.Find("First Person Controller").SendMessage("SetControllable", true);
        ShooterStarter.gameIsEnabled = false;
        //isNewStarted = false;
    }
}

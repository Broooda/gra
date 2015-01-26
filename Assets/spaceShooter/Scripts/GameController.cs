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
    public bool isNewStarted;

    public TextMesh text3D;

    private bool gameOver;
    private bool restart;
    private int score;
    private bool startCoroutine;

    void Start()
    {
        startCoroutine = false;
        //isNewStarted = false;
        gameOver = true;
        restart = false;
        text3D.text = "";
        score = 0;
        isNewStarted = false;
    }

    void Update()
    {
        if (ShooterStarter.gameIsEnabled)
        {
            if ((ShooterStarter.gameIsEnabled) && !isNewStarted) 
            {
                text3D.text = "";
                this.audio.Play();
                enemyShip.audio.mute = false;
                CameraManager.SelectCamera(2);
                startCoroutine = true;
                isNewStarted = true;
            }
        }
        if (startCoroutine)
        {
            StartCoroutine(SpawnWaves());
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StopCoroutine(SpawnWaves());
                isNewStarted = false;
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        startCoroutine = false;
        gameOver = false;
        restart = false;

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
                text3D.text = "Game Over";
                yield return new WaitForSeconds(2);
                text3D.text = "Press 'R' for Restart";
                restart = true;
                yield break;
            }
        }
        for (int i = 0; i <= waveEnemyShipCount; i++)
        {
            if (gameOver)
            {
                text3D.text = "Game Over";
                yield return new WaitForSeconds(2);
                text3D.text = "Press 'R' for Restart";
                restart = true;
                yield break;
            }
            if (i < waveEnemyShipCount)
            {
                Vector3 spawnPosition = new Vector3(Random.RandomRange(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                spawnPosition += parentObject.transform.position;
                GameObject local = Instantiate(enemyShip, spawnPosition, enemyShip.transform.rotation) as GameObject;
                local.transform.parent = parentObject.transform;
                yield return new WaitForSeconds(waveWait);
            }
        }
        yield return new WaitForSeconds(6);
        if (gameOver)
        {
            text3D.text = "Game Over";
            yield return new WaitForSeconds(2);
            text3D.text = "Press 'R' for Restart";
            restart = true;
            yield break;
        }
        if (!gameOver)
        {
            text3D.text = "You Won";
            yield return new WaitForSeconds(2);
            this.audio.Stop();
            CameraManager.SelectCamera(0);
            GameObject.Find("First Person Controller").SendMessage("SetControllable", true);
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}

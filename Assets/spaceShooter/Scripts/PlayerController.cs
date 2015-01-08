using UnityEngine;
using System.Collections;
using Assets.Scripts.ReuseableClasses;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundry boundry;
    public float tilt;

    public GameObject playerExplosion;
    public GameController gameController;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (CameraManager.cameras[2].activeSelf && Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundry.xMin, boundry.xMax),
            25.0f,
            Mathf.Clamp(rigidbody.position.z, boundry.zMin, boundry.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Bolt")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Destroy(other.gameObject);//niszczy pocisk lub statek, zależy czyj collider wejdzie w collider asteroidy 
            Destroy(gameObject);//niszczy gracza
        }
    }
}


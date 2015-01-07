using UnityEngine;
using System.Collections;
using Assets.Scripts.ReuseableClasses;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Start()
    {
        rigidbody.velocity = transform.forward * speed;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }
}

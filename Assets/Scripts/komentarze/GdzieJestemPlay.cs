using UnityEngine;
using System.Collections;

public class GdzieJestemPlay : MonoBehaviour
{
    public AudioSource[] sounds;
    
    public AudioSource gdzieJestem;
    private bool wasPlayedOnce;

    private AudioSource latarka;
    private AudioSource greenKey;
    private AudioSource redKey;
    private AudioSource goldKey;
    private AudioSource silverKey;
    private AudioSource blueKey;
    private AudioSource UV;
    private AudioSource fridge;
    private AudioSource tablet;
    private AudioSource torrentino;


	// Use this for initialization
	void Start ()
    {
        sounds = GetComponents<AudioSource>();
        gdzieJestem = sounds[0];
        latarka = sounds[1];
        greenKey = sounds[2];
        redKey = sounds[3];
        goldKey = sounds[4];
        silverKey = sounds[5];
        blueKey = sounds[6];
        UV = sounds[7];
        fridge = sounds[8];
        tablet = sounds[9];
        torrentino = sounds[10];
        
        wasPlayedOnce = false;
	}

    void Update()
    {
        if (!wasPlayedOnce)
        {
            gdzieJestem.PlayDelayed(3);
            wasPlayedOnce = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GreenK")
        {
            greenKey.Play();
        }
        if (other.tag == "RedK")
        {
            redKey.Play();
        }
        if (other.tag == "GoldK")
        {
            goldKey.Play();
        }
        if (other.tag == "SilverK")
        {
            silverKey.Play();
        }
        if (other.tag == "BlueK")
        {
            blueKey.Play();
        }
        if (other.tag == "Latarka")
        {
            latarka.Play();
        }
        if (other.tag == "UV")
        {
            UV.Play();
        }
        if (other.tag == "Fridge")
        {
            fridge.Play();
        }
        if (other.tag == "Tablet")
        {
            tablet.Play();
        }
        if (other.tag == "Torrentino")
        {
            torrentino.Play();
        }
    }
}

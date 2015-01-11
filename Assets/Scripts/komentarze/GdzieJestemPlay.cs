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
			hud.showText("Zielony klucz");
            greenKey.Play();
        }
        if (other.tag == "RedK")
        {
			hud.showText("Czerwony klucz");
            redKey.Play();
        }
        if (other.tag == "GoldK")
        {
			hud.showText("Zloty klucz");
            goldKey.Play();
        }
        if (other.tag == "SilverK")
        {
			hud.showText("Srebrny klucz");
            silverKey.Play();
        }
        if (other.tag == "BlueK")
        {
			hud.showText("Niebieski klucz");
            blueKey.Play();
        }
        if (other.tag == "Latarka")
        {
			hud.showText("Latarka");
            latarka.Play();
        }
        if (other.tag == "UV")
        {
			hud.showText("Latarka UV");
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
	void OnTriggerExit(){
		hud.showinfo = false;
	}
}

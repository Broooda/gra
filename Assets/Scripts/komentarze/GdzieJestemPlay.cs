using UnityEngine;
using System.Collections;

public class GdzieJestemPlay : MonoBehaviour
{
    public AudioSource[] sounds;
    
    public AudioSource gdzieJestem;
    private bool wasPlayedOnce;

    private AudioSource latarka;
    private bool playedOnce1 = false;

    private AudioSource greenKey;
    private bool playedOnce2 = false;

    private AudioSource redKey;
    private bool playedOnce3 = false;

    private AudioSource goldKey;
    private bool playedOnce4 = false;

    private AudioSource silverKey;
    private bool playedOnce5 = false;

    private AudioSource blueKey;
    private bool playedOnce6 = false;

    private AudioSource UV;
    private bool playedOnce7 = false;

    private AudioSource fridge;
    private bool playedOnce8 = false;

    private AudioSource tablet;
    private bool playedOnce9 = false;

    private AudioSource torrentino;
    private bool playedOnce10 = false;

    public GameObject mainCamera;



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
        if (!wasPlayedOnce && mainCamera.activeInHierarchy)
        {
            gdzieJestem.PlayDelayed(3);
            wasPlayedOnce = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GreenK" && !playedOnce1 && MainGameScript.BlockWin)
        {
			hud.showText("Zielony klucz");
            greenKey.Play();
            playedOnce1 = true;
        }
        if (other.tag == "RedK" && !playedOnce2)
        {
			hud.showText("Czerwony klucz");
            redKey.Play();
            playedOnce2 = true;
        }
        if (other.tag == "GoldK" && !playedOnce3 && tarantinoCode.codeOk)
        {
			hud.showText("Zloty klucz");
            goldKey.Play();
            playedOnce3 = true;
        }
        if (other.tag == "SilverK" && !playedOnce4)
        {
			hud.showText("Srebrny klucz");
            silverKey.Play();
            playedOnce4 = true;
        }
        if (other.tag == "BlueK" && !playedOnce5)
        {
			hud.showText("Niebieski klucz");
            blueKey.Play();
            playedOnce5 = true;
        }
        if (other.tag == "Latarka" && !playedOnce6)
        {
			hud.showText("latarka");
            latarka.Play();
            playedOnce6 = true;
        }
        if (other.tag == "UV" && !playedOnce7)
        {
            hud.showText("UV");
            UV.Play();
            playedOnce7 = true;
        }
        if (other.tag == "Fridge" && !playedOnce8)
        {
            fridge.Play();
            playedOnce8 = true;
        }
        if (other.tag == "Tablet" && !playedOnce9)
        {
            tablet.Play();
            playedOnce9 = true;
        }
        if (other.tag == "Torrentino" && !playedOnce10)
        {
            torrentino.Play();
            playedOnce10 = true;
        }
    }
	void OnTriggerExit(){
		hud.showinfo = false;
	}
}

﻿using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	private bool _isFirstMenu = true;
	//private bool _isLevelSelectMenu = false;
	private bool _isOptionsMenu = false;
	private bool _isAudioOptions = false;
	private bool _isGraphicOptions = false;
	public string gameTitle = "Name this game";

	private float _gameVolume = 0.6f;
	private float _gameFOV = 60.0f;

	public Camera gameCamera;
	



	// Use this for initialization
	void Start ()
	{

		//PlayerPrefs.DeleteAll ();
		_gameVolume = PlayerPrefs.GetFloat ("Game Volume", _gameVolume);
		_gameFOV = PlayerPrefs.GetFloat ("Game FOV", _gameFOV);

		if (PlayerPrefs.HasKey ("Game Volume")) {
						AudioListener.volume = PlayerPrefs.GetFloat ("Game Volume");
		} else
		{
			PlayerPrefs.SetFloat("Game Volume",_gameVolume);
		}
		if (PlayerPrefs.HasKey ("Game FOV")) {
						gameCamera.fieldOfView = PlayerPrefs.GetFloat ("Game FOV");
				} else {
			PlayerPrefs.SetFloat("Game FOV", _gameFOV);
				}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void OnGUI()
	{
		//GUI.Label (new Rect (30, 75, 300, 25), gameTitle);

		FirstMenu ();
		OptionsMenu ();
		AudioOptionsDisplay ();
		GraphicOptionsDisplay ();
		if (_isOptionsMenu == true)
		{
			if(GUI.Button(new Rect(10, Screen.height -35,150,25),"Back"))
			{
				_isOptionsMenu = false;
				_isFirstMenu = true;
				_isAudioOptions = false;
				_isGraphicOptions = false;
			}
		}
	}
	void FirstMenu()
	{
		if (_isFirstMenu)
		{
			if(GUI.Button(new Rect(10, Screen.height / 2 - 100, 150,25),"New Game"))
			{
				Application.LoadLevel("main");
			}
			if(GUI.Button(new Rect(10, Screen.height / 2 - 65, 150,25),"Options"))
			{
				_isFirstMenu = false;
				_isOptionsMenu = true;
			}
			if(GUI.Button(new Rect(10, Screen.height / 2 - 30, 150,25),"Quit Game"))
			{
				Application.Quit();
			}
		}
	}
	void OptionsMenu()
	{
		if (_isOptionsMenu)
		{
			//GUI.Label(new Rect(10, Screen.height /2 -200, 200,50), "Options", "Sub Menu Title");
			if(_isAudioOptions == true || _isGraphicOptions ==true)
			{
			GUI.Box(new Rect(Screen.height/2, 0, Screen.width/2,Screen.height), "");
			}
			if(GUI.Button(new Rect(10,Screen.height/2 - 30,150,25),"Audio Options"))
			{
				_isGraphicOptions = false;
				_isAudioOptions = true;
			}
			if(GUI.Button(new Rect(10,Screen.height/2 + 5,150,25),"Video Options"))
			{
				_isAudioOptions = false;
				_isGraphicOptions = true;
			}
		}
	}
	public void AudioOptionsDisplay()
	{
		if (_isAudioOptions)
		{
			GUI.Label(new Rect(Screen.width /2 +10, 115,200,25),"Game Volume:");
			_gameVolume = GUI.HorizontalSlider(new Rect(Screen.width/2 + 10, 150, Screen.width/2 -55,25),_gameVolume,0.0f, 1.0f);
			GUI.Label(new Rect(Screen.width -35,145,50,25),"" + (System.Math.Round (_gameVolume,2)));
			AudioListener.volume = _gameVolume;
			if(GUI.Button(new Rect(Screen.width/2 + 10, Screen.height - 35,150,25),"Apply"))
			{
				PlayerPrefs.SetFloat("Game Volume", _gameVolume);
			}
		}
	}
	public void GraphicOptionsDisplay()
	{
		if (_isGraphicOptions)
		{
			GUI.Label(new Rect(Screen.width /2 +10, 115,200,25),"Game FOV:");
			_gameFOV = GUI.HorizontalSlider(new Rect(Screen.width/2 + 10, 150, Screen.width/2 -55,25),_gameFOV,40.0f, 100.0f);
			GUI.Label(new Rect(Screen.width -35,145,50,25),"" + (int)_gameFOV);
			gameCamera.fieldOfView = _gameFOV;

			GUILayout.BeginVertical();
			GUI.Label (new Rect(Screen.width/2 +10,200,200,25),"Graphics Quality");
			for(int i = 0; i< QualitySettings.names.Length; i++)
			{
				if(GUI.Button(new Rect(Screen.width/2 +30, 235 + i*35,150,25),QualitySettings.names[i]))
				{
					QualitySettings.SetQualityLevel(i, true);
				}
			}
			GUILayout.EndVertical();

			if(GUI.Button(new Rect(Screen.width/2 + 10, Screen.height - 35,150,25),"Apply"))
			{
				PlayerPrefs.SetFloat("Game FOV", _gameFOV);
			}
		}
	}
}
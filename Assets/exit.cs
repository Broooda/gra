﻿using UnityEngine;
using System.Collections;

public class exit : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
            Screen.showCursor = true;
        }
	}
}

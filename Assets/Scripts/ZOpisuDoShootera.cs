using UnityEngine;
using System.Collections;

public class ZOpisuDoShootera : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space) && camera.enabled)
        {
            CameraManager.SelectCamera(2);
            ShooterStarter.gameIsEnabled = true;
        }
	}
}

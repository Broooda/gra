using UnityEngine;
using System.Collections;

public class ZOpisDoLockPicking : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && camera.enabled)
        {
            CameraManager.SelectCamera(5);
        }
    }
}

using UnityEngine;
using System.Collections;

public class ZOpisDoGlownaGra : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && camera.enabled)
        {
            CameraManager.SelectCamera(0);
        }
    }
}

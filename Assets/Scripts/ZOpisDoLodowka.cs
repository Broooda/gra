using UnityEngine;
using System.Collections;

public class ZOpisDoLodowka : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && camera.enabled)
        {
            CameraManager.SelectCamera(1);
        }
    }
}

using UnityEngine;
using System.Collections;

public class TarantinoDoor : MonoBehaviour
{
    private bool param = false;
    private bool doorIsOpen = false;
    public int speedOpen = 100;
    void Update()
    {
        if (ShooterStarter.gameIsEnabled)
        {
            if (!doorIsOpen)
            {
                transform.FindChild("body").Translate(Vector3.right * 0.04f * speedOpen);
            }
        }
        if (transform.FindChild("body").transform.position.z < -15.55)
        {
            doorIsOpen = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcha : MonoBehaviour
{
    public GameObject thisCamera;
    public GameObject thatCamera;

    public void grund()
    {
        Debug.Log("scream");
        thisCamera.SetActive(false);
        thatCamera.SetActive(true);
    }

}

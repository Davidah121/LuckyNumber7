using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCamSwitcha : MonoBehaviour, interactable
{
    public void interact()
    {
        gameObject.GetComponent<CamSwitcha>().grund();
        Debug.Log("scream");
    }

    public void interact(int itemcode)
    {
        //nothing method
    }
}

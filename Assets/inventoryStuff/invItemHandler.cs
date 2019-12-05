using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invItemHandler : MonoBehaviour
{
    //set in inspector because I say so
    public int itemcode;
    public GameObject mainCam;
    public GameObject invWindow;

    //onmouseup so users can cancel by dragging away
    public void invokeCode()
    {
        mainCam.GetComponent<DeadSimpleClickHandler>().currentItemCode = itemcode;
    }
}

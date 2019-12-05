using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button3Handler : MonoBehaviour, interactable {
    public GameObject button;

    public void interact()
    {
        button.GetComponent<button1Handler>().reset();
    }

    public void interact(int itemcode)
    {
        //placeholder that does nothing
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2Handler : MonoBehaviour, interactable {
    public GameObject button1;
    public void interact()
    {
        button1.GetComponent<button1Handler>().increment2();
    }
    
    public void interact(int itemcode)
    {

    }

}

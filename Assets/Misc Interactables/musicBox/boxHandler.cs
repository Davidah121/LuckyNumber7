using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxHandler : MonoBehaviour, interactable
{
    public GameObject inventory;
    public GameObject switcher;

    public void interact()
    {
        //nothing
    }

    public void interact(int itemcode)
    {
        if(itemcode == 3)
        {
            inventory.GetComponent<inventoryController>().hasWindKey = false;
            inventory.GetComponent<inventoryController>().hasSpool = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inkInteract : MonoBehaviour, interactable
{
    public GameObject inventory;

    public void interact()
    {
        //nothing
    }

    public void interact(int itemcode)
    {
        if(itemcode == 1)
        {
            inventory.GetComponent<inventoryController>().hasSpool = false;
            inventory.GetComponent<inventoryController>().hasInkySpool = true;
        }
    }

}

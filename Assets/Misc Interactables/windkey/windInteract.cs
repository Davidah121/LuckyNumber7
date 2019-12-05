using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windInteract : MonoBehaviour, interactable
{
    public GameObject inventory;

    public void interact()
    {
        inventory.GetComponent<inventoryController>().hasWindKey = true;
        gameObject.SetActive(false);
    }

    public void interact(int itemcode)
    {
        //placeholder nothing
    }

}

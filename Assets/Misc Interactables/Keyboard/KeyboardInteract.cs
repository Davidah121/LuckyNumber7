using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInteract : MonoBehaviour, interactable
{
    public GameObject keyboard;
    public void interact()
    {
        keyboard.SetActive(true);
    }
    public void interact(int number)
    {
        //placeholder nothing method
    }
}

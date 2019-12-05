using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deskPaperInt : MonoBehaviour, interactable
{
    public GameObject blanksheet;
    public GameObject inksheet;
    public GameObject sheetUI;
    bool done = false;
    public void interact()
    {
        if (done)
        {
            //show a close-up of the note
            sheetUI.SetActive(true);
        }
        else
        {
            //placeholder nothing method
        }
    }

    public void interact(int itemcode)
    {
        if(itemcode == 4)
        {
            blanksheet.SetActive(false);
            inksheet.SetActive(true);
            done = true;
        }
    }
}

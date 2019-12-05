using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxHandler : MonoBehaviour, interactable
{
    public GameObject inventory;
    public GameObject switcher;
    public GameObject guicontrol;
    bool solved = false;

    public void interact()
    {
        //nothing
        if (solved)
        {
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 3;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
        else
        {
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 4;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
    }

    public void interact(int itemcode)
    {
        if(itemcode == 3)
        {
            solved = true;
            inventory.GetComponent<inventoryController>().hasWindKey = false;
            inventory.GetComponent<inventoryController>().hasSpool = true;
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 6;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
        else
        {
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 3;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
    }
}

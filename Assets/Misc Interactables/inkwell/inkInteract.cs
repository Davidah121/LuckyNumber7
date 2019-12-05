using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inkInteract : MonoBehaviour, interactable
{
    public GameObject inventory;
    public GameObject switcher;
    public GameObject guicontrol;

    public void interact()
    {
        switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
        guicontrol.GetComponent<GuiController>().cutsceneNumber = 7;
        guicontrol.GetComponent<GuiController>().phaseReset();
    }

    public void interact(int itemcode)
    {
        if(itemcode == 1)
        {
            inventory.GetComponent<inventoryController>().hasSpool = false;
            inventory.GetComponent<inventoryController>().hasInkySpool = true;
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 8;
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

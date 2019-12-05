using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windInteract : MonoBehaviour, interactable
{
    public GameObject inventory;
    public GameObject switcher;
    public GameObject guicontrol;

    public void interact()
    {
        inventory.GetComponent<inventoryController>().hasWindKey = true;
        switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
        guicontrol.GetComponent<GuiController>().cutsceneNumber = 5;
        guicontrol.GetComponent<GuiController>().phaseReset();
        gameObject.SetActive(false);
    }

    public void interact(int itemcode)
    {
        switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
        guicontrol.GetComponent<GuiController>().cutsceneNumber = 3;
        guicontrol.GetComponent<GuiController>().phaseReset();
    }

}

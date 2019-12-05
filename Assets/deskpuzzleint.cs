using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deskpuzzleint : MonoBehaviour, interactable
{
    public GameObject switcher;
    public GameObject guicontrol;

    public void interact()
    {
        switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
        guicontrol.GetComponent<GuiController>().cutsceneNumber = 12;
        guicontrol.GetComponent<GuiController>().phaseReset();
    }

    public void interact(int itemcode)
    {
        switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
        guicontrol.GetComponent<GuiController>().cutsceneNumber = 3;
        guicontrol.GetComponent<GuiController>().phaseReset();
    }
}

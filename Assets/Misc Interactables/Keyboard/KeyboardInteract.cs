using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInteract : MonoBehaviour, interactable
{

    public GameObject switcher;
    public GameObject guicontrol;
    public bool useable = false;
    public GameObject keyboard;
    public void interact()
    {
        if (useable)
        {
            keyboard.SetActive(true);
        }
        else
        {
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 13;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
    }
    public void interact(int number)
    {
        switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
        guicontrol.GetComponent<GuiController>().cutsceneNumber = 3;
        guicontrol.GetComponent<GuiController>().phaseReset();
    }
}

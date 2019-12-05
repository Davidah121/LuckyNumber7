using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deskPaperInt : MonoBehaviour, interactable
{
    public GameObject blanksheet;
    public GameObject inksheet;
    public GameObject sheetUI;
    public GameObject switcher;
    public GameObject guicontrol;

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
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 9;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
    }

    public void interact(int itemcode)
    {
        if(itemcode == 4)
        {
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 10;
            guicontrol.GetComponent<GuiController>().phaseReset();
            blanksheet.SetActive(false);
            inksheet.SetActive(true);
            done = true;
        }
        else
        {
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 3;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
    }
}

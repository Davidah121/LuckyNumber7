using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInt : MonoBehaviour, interactable
{
    public GameObject switcher;
    public GameObject guicontrol;
    public bool unlocked = false;
    private int distance;
    public int x;
    public int y;
    public int z;
    public GameObject cam;
    public GameObject wengis;
    private float time;
    private bool blind;

    public void interact()
    {
        if (unlocked)
        {
            cam.transform.Translate(new Vector3(x, y, z));
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 2;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
        else
        {
            //switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            //guicontrol.GetComponent<GuiController>().cutsceneNumber = 11;
            //guicontrol.GetComponent<GuiController>().phaseReset();
        }
    }

    public void interact(int itemcode)
    {
        switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
        guicontrol.GetComponent<GuiController>().cutsceneNumber = 3;
        guicontrol.GetComponent<GuiController>().phaseReset();
    }

    public void Update()
    {
        if (blind)
        {
            time += Time.deltaTime;
            if (time > 1)
            {
                blind = false;
                time = 0;
                wengis.SetActive(false);
            }
        }
    }
}

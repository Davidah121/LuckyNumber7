using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttong : MonoBehaviour, interactable
{
    public GameObject bord;
    public GameObject switcher;
    public GameObject guicontrol;


    public GameObject bung1;
    public GameObject bung2;
    public GameObject bung3;
    public GameObject bung4;
    public GameObject bung5;
    public GameObject bung6;
    public GameObject bung7;
    public GameObject bung8;
    public GameObject bung9;

    private LetterKeyHandler scrung1;
    private LetterKeyHandler scrung2;
    private LetterKeyHandler scrung3;
    private LetterKeyHandler scrung4;
    private LetterKeyHandler scrung5;
    private LetterKeyHandler scrung6;
    private LetterKeyHandler scrung7;
    private LetterKeyHandler scrung8;
    private LetterKeyHandler scrung9;



    public void Start()
    {
        scrung1 = bung1.GetComponent<LetterKeyHandler>();
        scrung2 = bung2.GetComponent<LetterKeyHandler>();
        scrung3 = bung3.GetComponent<LetterKeyHandler>();
        scrung4 = bung4.GetComponent<LetterKeyHandler>();
        scrung5 = bung5.GetComponent<LetterKeyHandler>();
        scrung6 = bung6.GetComponent<LetterKeyHandler>();
        scrung7 = bung7.GetComponent<LetterKeyHandler>();
        scrung8 = bung8.GetComponent<LetterKeyHandler>();
        scrung9 = bung9.GetComponent<LetterKeyHandler>();
    }
    public void interact()
    {
        if(scrung1.checkCorrect()&& scrung2.checkCorrect() && scrung3.checkCorrect() && scrung4.checkCorrect() && scrung5.checkCorrect() && scrung6.checkCorrect() && scrung7.checkCorrect() && scrung8.checkCorrect() && scrung9.checkCorrect())
        {
            Debug.Log("YAY");
            bord.GetComponent<KeyboardInteract>().useable = true;
            switcher.GetComponent<contextSwitch>().setMode(contextSwitch.VISUAL_NOVEL_MODE);
            guicontrol.GetComponent<GuiController>().cutsceneNumber = 14;
            guicontrol.GetComponent<GuiController>().phaseReset();
        }
        else
        {
            Debug.Log("FUCK");
        }

    }
    public void interact(int i)
    {
        //placeholder nothing
    }

}

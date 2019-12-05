using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterKeyHandler : MonoBehaviour, interactable
{
    public int xPos;
    public int yPos;
    public int correctX;
    public int correctY;
    private LetterKeyFather Dad;

    void Start()
    {
        Dad = this.GetComponentInParent<LetterKeyFather>();
    }

    public void interact()
    {
        Debug.Log("Weeng");
        if (Dad.hasBlock)
        {
            if (Dad.selection == this)
            {
                Dad.selection = null;
                Dad.hasBlock = false;
            }
            else
            {
                Dad.selection.gameObject.transform.position = gameObject.transform.position;
                Dad.selection.xPos = this.xPos;
                Dad.selection.yPos = this.yPos;
                gameObject.transform.position = Dad.selectPos;
                this.xPos = Dad.selectX;
                this.yPos = Dad.selectY;
                Dad.selection = null;
                Dad.hasBlock = false;
            }
        }
        else
        {
            Dad.selection = this;
            Dad.hasBlock = true;
            Dad.selectX = xPos;
            Dad.selectY = yPos;
            Dad.selectPos = gameObject.transform.position;

        }
    }
    public void interact(int i)
    {

    }
    public bool checkCorrect()
    {
        if (xPos == correctX && yPos == correctY)
        {
            return true;
        }
        else return false;
    }

}

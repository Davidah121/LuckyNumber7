using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1Handler : MonoBehaviour, interactable {
    private int keypad;
    public void Start()
    {
        keypad = 0;
    }
    public void interact()
    {
        Debug.Log("keypad " + keypad);
        if(keypad == 0)
        {
            increment();
        }
        else if(keypad == 2)
        {
            succeed();
        }
        else
        {
            reset();
        }
    }

    public void interact(int itemcode)
    {
        //placeholder that does nothing
    }

    public void increment()
    {
        Debug.Log("keypad incremented");
        keypad++;
    }
    public void increment2()
    {
        if (keypad == 1) increment();
        else reset();
    }
    public void succeed()
    {
        Debug.Log("keypad success");
        gameObject.GetComponent<AudioSource>().Play();
        reset();
    }
    public void reset()
    {
        Debug.Log("Keypad reset");
        keypad = 0;
    }
}

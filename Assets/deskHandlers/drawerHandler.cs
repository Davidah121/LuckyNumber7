using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerHandler : MonoBehaviour, interactable {
    bool open = false;
    public void interact()
    {
        Debug.Log("interact method called");
        if (open)
        {
            open = false;
            gameObject.transform.Translate(0, 0, -1.2f);
        }
        else
        {
            open = true;
            gameObject.transform.Translate(0, 0, 1.2f);
        }
            
    }

    public void interact(int itemcode)
    {
        //placeholder that does nothing
    }
}

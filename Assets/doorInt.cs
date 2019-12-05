using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInt : MonoBehaviour, interactable
{
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
            time = 0;
            blind = true;
            wengis.SetActive(true);
        }
        else
        {
            //it's locked...
        }
    }

    public void interact(int itemcode)
    {
        //placeholder that does nothing
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

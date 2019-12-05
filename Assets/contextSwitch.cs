using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contextSwitch : MonoBehaviour
{
    public bool VNMode = false;

    public const bool VISUAL_NOVEL_MODE = true;
    public const bool EXPLORE_MODE = false;

    public GameObject vnObj = null;
    public GameObject pzObj = null;

    public bool getMode()
    {
        return VNMode;
    }

    public void setMode(bool m)
    {
        VNMode = m;
        GameObject k;
        switch (VNMode)
        {
            case VISUAL_NOVEL_MODE:
                vnObj.SetActive(true);
                pzObj.SetActive(false);
                break;
            case EXPLORE_MODE:
                vnObj.SetActive(false);
                pzObj.SetActive(true);

                break;
            default:
                break;
        }
    }

    private void setPuzzleThing()
    {
        setMode(VISUAL_NOVEL_MODE);
    }

    // Start is called before the first frame update
    void Start()
    {
        vnObj = GameObject.Find("VNMode");
        pzObj = GameObject.Find("PuzzleMode");

        if(VNMode==VISUAL_NOVEL_MODE)
            Invoke("setPuzzleThing", 0.05f);


        setMode(EXPLORE_MODE);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            setMode(!getMode());
        }
    }
}

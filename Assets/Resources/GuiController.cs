using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public GameObject[] npcs;

    //not necessarly required, but does not require an npc to be visible.
    //this can be good for intercoms or something that is not visible.
    public GameObject narrator = null;

    int phase = -1;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<npcs.Length; i++)
        {
            NpcScript k = npcs[i].GetComponent<NpcScript>();
            k.disappear();
        }
    }

    void updatePhase()
    {
        NpcScript k = null;
        switch (phase)
        {
            case 0:
                k = npcs[0].GetComponent<NpcScript>();
                k.appear();
                k.name = "default-kun";
                k.whatToSay = "Nothing cause im default.";

                k.speak();
                break;

            case 1:
                k = npcs[1].GetComponent<NpcScript>();
                k.appear();
                k.name = "def-chan";
                k.whatToSay = "I am also default.";

                k.speak();
                break;

            case 2:
                k = npcs[0].GetComponent<NpcScript>();
                k.changeSprite(1);

                k = npcs[1].GetComponent<NpcScript>();
                k.changeSprite(1);

                k = narrator.GetComponent<NpcScript>();
                k.name = "Tyler Senpai";
                k.whatToSay = "Lets disappear.";
                k.speak();

                break;

            case 3:
                k = npcs[0].GetComponent<NpcScript>();
                k.disappear();
                k = npcs[1].GetComponent<NpcScript>();
                k.disappear();

                k = narrator.GetComponent<NpcScript>();
                k.whatToSay = "";
                k.name = "";
                k.speak();
                break;

            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            phase++;
            updatePhase();
        }
    }
}

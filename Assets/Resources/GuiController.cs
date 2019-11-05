using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public GameObject[] npcs;

    //not necessarly required, but does not require an npc to be visible.
    //this can be good for intercoms or something that is not visible.
    public GameObject narrator = null;
    public GameObject switcher = null;

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

    void cutscene1()
    {
        NpcScript k = null;
        switch (phase)
        {
            case 0:
                k = narrator.GetComponent<NpcScript>();
                k.name = "";
                k.whatToSay = "[Damien wakes up with blurry vision and as his vision clears up, he sees that he is in a classroom.]";

                k.speak();
                break;

            case 1:
                k = npcs[0].GetComponent<NpcScript>();
                k.appear();
                k.name = "Damien";
                k.whatToSay = "[Agh. My head. It feels like it's splitting open. Where am I? I'm in... a classroom?] Welcome to my school! Solve my first test or you'll never leave!";

                k.speak();
                break;

            case 2:
                k = npcs[0].GetComponent<NpcScript>();
                k.appear();
                k.name = "Damien";
                k.whatToSay = "[I feel my heart begin to pound. I see the door and rush towards it. It’s locked. Darn. Well, I guess I should have a look around. If this is some kind of test, then maybe if I solve it, I can leave.]";

                k.speak();
                break;

            case 43124324:
                //transform.Find("VNMode/FrontCanvas/RightTransMask").GetComponent<Image>()
                break;
            case 3:

                switcher.GetComponent<contextSwitch>().setMode(contextSwitch.EXPLORE_MODE);
                break;
            default:
                break;
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
            cutscene1();
        }
    }
}

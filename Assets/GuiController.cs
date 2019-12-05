using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public GameObject[] npcs;
    public int cutsceneNumber = 1;
    /*
     * 0 - Phil
     * 1 - Nona
     * 2 - Bebe
     * 3 - Masque
     * 4 - Simon
     * 5 - Rich
     * 6 - Playtime
     */
    //not necessarly required, but does not require an npc to be visible.
    //this can be good for intercoms or something that is not visible.
    public GameObject narrator = null;
    public GameObject switcher = null;
    public TransitionScript transition = null;
    public TransitionScript2 fullTransition = null;
    public bool canChange = true;
    int phase = -1;
    // Start is called before the first frame update
    void Start()
    {
        transition = GameObject.Find("VNMode/FrontCanvas/Transition").GetComponent<TransitionScript>();
        fullTransition = GameObject.Find("VNMode/FrontCanvas/FullTransition").GetComponent<TransitionScript2>();
        for(int i=0; i<npcs.Length; i++)
        {
            NpcScript k = npcs[i].GetComponent<NpcScript>();
            if (i % 2 == 1)
                k.moveLeftSide();
            else
                k.moveRightSide();

            k.disappearInstant();
            k.moveOutScene();
        }
        transition.appearInstant();
        fullTransition.disappearInstant();
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
                canChange = false;
                transition.disappear();
                if(transition.getAlpha()<=0f)
                {
                    canChange = true;
                    phase += 1;
                }
                break;
            case 2:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "[Agh. My head. It feels like it's splitting open. Where am I? I'm in... a classroom?] Welcome to my school! Solve my first test or you'll never leave!";

                k.speak();
                break;
            case 3:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "[I feel my heart begin to pound. I see the door and rush towards it. It’s locked. Darn. Well, I guess I should have a look around. If this is some kind of test, then maybe if I solve it, I can leave.]";

                k.speak();
                break;
            case 4:
                canChange = false;
                fullTransition.appear();
                if (fullTransition.getAlpha() >= 1f)
                {
                    canChange = true;
                    phase += 1;
                }
                break;
            case 5:
                switcher.GetComponent<contextSwitch>().setMode(contextSwitch.EXPLORE_MODE);
                break;
            default:
                break;
        }
    }

    void cutscene2()
    {
        NpcScript k = null;
        switch (phase)
        {
            case 0:
                canChange = false;
                transition.disappear();
                if (transition.getAlpha() <= 0f)
                {
                    canChange = true;
                    phase += 1;
                }
                break;
            case 1:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "There, I’m out. What a weird way to trap someone. Hopefully, this door will lead me to answers. It looks like I’m in some kind of weird school. But this isn’t my school. It looks pretty old. Kind of worn down. I see an arrow pointing me to my left. It looks like it was drawn in… crayon. I scratch my head and follow the arrow.";

                k.speak();
                break;
            case 2:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "I run down the hallway to see what fate awaited me. If I knew what would await me, I would have stayed in the classroom.";

                k.speak();
                break;
            case 3:
                k = npcs[0].GetComponent<NpcScript>();
                k.name = "Muscular Guy";
                k.whatToSay = "So, that makes seven of us. I wonder if that’s it.";
                k.moveLeftSide();

                k.appear();
                k.speak();

                canChange = false;
                if(k.getAlpha()>=1f)
                {
                    canChange = true;
                }

                break;
            case 4:
                k = npcs[1].GetComponent<NpcScript>();
                k.name = "Blonde Girl";
                k.whatToSay = "I hope so. Maybe then whoever trapped us here will give us some ans-";
                k.moveRightSide();
                k.appear();
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }

                break;
            case 5:
                //phil disappers
                k = npcs[0].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Rude Girl";
                k.whatToSay = "Took ya long enough you dimwit. We were all done with our puzzles like twenty minutes ago. Even the creepy girl made it here before you.";
                k.moveLeftSide();
                k.appear();
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 6:
                //nona disappers
                k = npcs[1].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter masque
                k = npcs[3].GetComponent<NpcScript>();
                k.name = "Masked Girl";
                k.whatToSay = "...";
                k.moveRightSide();
                k.appear();
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 7:
                //bebe disappers
                k = npcs[2].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter simon
                k = npcs[4].GetComponent<NpcScript>();
                k.name = "Shy Boy";
                k.whatToSay = "W-Why are we all here?";
                k.moveLeftSide();
                k.appear();
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 8:
                //masque disappers
                k = npcs[3].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter rich
                k = npcs[5].GetComponent<NpcScript>();
                k.name = "Snobbish Boy";
                k.whatToSay = "They’re probably kidnapping us so our parents pay a ransom. That would make the most sense.";
                k.moveRightSide();
                k.appear();
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 9:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(I shake my head) No, my parents aren’t rich enough for someone to kidnap me just for ransom. Also, if it was just that, why make us solve puzzles?";
                k.speak();
                break;
            case 10:
                //page 2
                //exit simon
                k = npcs[4].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Rude Girl";
                k.whatToSay = "AAAAHHHH. Whatever! Let us out of here… whoever!";
                k.moveLeftSide();
                k.appear();
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 11:
                //exit bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(The girl starts banging on the door with the butterfly on it)";

                k.speak();

                break;
            case 12:
                
                k = npcs[0].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Muscular Guy";
                k.whatToSay = "Hey, stop that. It’s not going to get us anywhere.";

                k.speak();
                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }

                break;
            case 13:
                k = npcs[5].GetComponent<NpcScript>();
                k.name = "Snobbish Boy";
                k.whatToSay = "I agree. Acting like a heathen won’t get us anywhere.";
                k.appear();

                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 14:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(She turned to him and she was seething with rage. That’s when I heard a faint laugh)";

                k.speak();

                break;
            case 15:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Young Voice";
                k.whatToSay = "Tee hee! You shouldn’t be fighting each other. You should be helping each other, you sillies!";

                k.speak();
                break;
            case 16:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(Appearing out of nowhere, there was a little girl at the top of the stairs. She had an eyepatch and a backpack with what looked like butterfly wings.)";

                k.speak();
                break;
            case 17:
                //exit rich
                k = npcs[5].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Playtime";
                k.whatToSay = "Hello, my big brothers and sisters! My name is Playtime! Welcome to my school! And welcome to my game! We’re going to have so much fun together! First, let’s introduce ourselves! Everyone! Now!";

                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 18:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(She pointed at me) Oh.. I’m Damien. (She then continues to point to the others)";

                k.speak();
                break;
            case 19:
                k = npcs[0].GetComponent<NpcScript>();
                k.name = "Phil";
                k.whatToSay = "Hm… My name’s Phil.";

                k.speak();
                break;
            case 20:
                //exit playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Nona
                k = npcs[1].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Nona";
                k.whatToSay = "I am Nona Cortex!";

                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 21:
                //exit phil
                k = npcs[0].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter snob
                k = npcs[5].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Rich";
                k.whatToSay = "Richard Fab. It’s a pleasure.";

                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 22:
                //exit nona
                k = npcs[1].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter thimon
                k = npcs[4].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Thimon?";
                k.whatToSay = "I-I’m Thimon…";

                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 23:
                //exit simon
                k = npcs[4].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Playtime";
                k.whatToSay = "Nope! That’s not right! Your name is Simon! Sorry, guys. He talks a little funny. Hehe.";

                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 24:
                k = narrator.GetComponent<NpcScript>();
                k.name = "";
                k.whatToSay = "(Simon turns an unbelievable shade of red.)";
                k.speak();
                break;
            case 25:
                //exit rich
                k = npcs[5].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Bebe";
                k.whatToSay = "Whatever. I am the fabulous Bebe Bloo. I’m sure you all know who I am. Top fashionista in the country. With over twenty-five million followers on WhoTube. And also rumored to be engaged to the ultra-wealthy Reginald Wallace. But don’t even bother getting me to confirm or deny it because I won’t let you in on a thing!";

                k.speak();
                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 26:
                //exit playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter phil
                k = npcs[0].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Phil";
                k.whatToSay = "I’ve… never heard of you.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 27:
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Bebe";
                k.whatToSay = "Wha?!";
                k.speak();

                break;
            case 28:
                //exit phil
                k = npcs[0].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter nona
                k = npcs[1].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Nona";
                k.whatToSay = "I don’t think I’ve ever heard of you either.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 29:
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Bebe";
                k.whatToSay = "H-How dare you!";
                k.speak();

                break;
            case 30:
                //exit nona
                k = npcs[1].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter simon
                k = npcs[4].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Simon";
                k.whatToSay = "She uses drama to get herself known without making content of any substances.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            default:
                break;
        }
    }

    void cutscene3()
    {
        NpcScript k = null;
        switch (phase)
        {
            case 0:
                k = narrator.GetComponent<NpcScript>();
                k.name = "";
                k.whatToSay = "Nothing of note happens.";

                k.speak();
                break;
            case 1:
                canChange = false;
                fullTransition.appear();
                if (fullTransition.getAlpha() >= 1f)
                {
                    canChange = true;
                    phase += 1;
                }
                break;
            case 2:
                switcher.GetComponent<contextSwitch>().setMode(contextSwitch.EXPLORE_MODE);
                break;
            default:
                break;
        }
    }

    void nextPhase()
    {
        if (canChange == true)
            phase++;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            nextPhase();
        }

        switch(cutsceneNumber)
        {
            case 1:
                cutscene1();
                break;
            case 2:
                cutscene2();
                break;
            default:
                break;
        }
    }
}

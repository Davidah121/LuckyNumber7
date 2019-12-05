using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
    public AudioSource conAudio = null;
    public AudioSource playTimeAudio = null;

    int phase = -1;
    // Start is called before the first frame update
    void Start()
    {
        conAudio = GameObject.Find("VNMode/GuiCamera/ConversationAudio").GetComponent<AudioSource>();
        playTimeAudio = GameObject.Find("VNMode/GuiCamera/PlaytimeTheme").GetComponent<AudioSource>();

        transition = GameObject.Find("VNMode/FrontCanvas/Transition").GetComponent<TransitionScript>();
        fullTransition = GameObject.Find("VNMode/FrontCanvas/FullTransition").GetComponent<TransitionScript2>();
        for(int i=0; i<npcs.Length; i++)
        {
            NpcScript k = npcs[i].GetComponent<NpcScript>();
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
                if(!conAudio.isPlaying)
                    conAudio.Play();

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
                if (conAudio.isPlaying)
                    conAudio.Stop();

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
                if (playTimeAudio.isPlaying)
                    playTimeAudio.Stop();
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
            case 31:
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Bebe";
                k.whatToSay = "You wanna go you emo punk?!";
                k.speak();

                break;
            case 32:
                k = npcs[4].GetComponent<NpcScript>();
                k.name = "Simon";
                k.whatToSay = "Ah! I-I didn’t say anything!";
                k.speak();
                break;
            case 33:
                //exit Simon
                k = npcs[4].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Playtime";
                k.whatToSay = "Ahem. I believe there is still someone who hasn't introduced themselves yet.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 34:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(We all looked at the girl with the creepy mask on her face. She hadn’t spoken since I got here.)";
                k.speak();
                break;
            case 35:
                //exit playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Masque
                k = npcs[3].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Masked Girl";
                k.whatToSay = "...";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 36:
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Bebe";
                k.whatToSay = "Well, say something.";
                k.speak();
                break;
            case 37:
                k = npcs[3].GetComponent<NpcScript>();
                k.name = "Masked Girl";
                k.whatToSay = "...";
                k.speak();
                break;
            case 38:
                //exit Masque
                k = npcs[3].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Playtime";
                k.whatToSay = "Well, it looks like she’s not feeling very talkative right now.  It seems she can’t give her name right now. For now, call her Masque.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 39:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(The girl still said nothing.)";
                k.speak();
                break;
            case 40:
                //exit Bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Rich
                k = npcs[5].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Richard";
                k.whatToSay = "Well, now that that’s out of the way, I think you should tell us why we’re here, little girl.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 41:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "Hey, my name isn’t “little girl.” My name is Playtime! And we’re here because I am bored! I wanna play a game.";
                k.speak();
                break;
            case 42:
                //exit Rich
                k = npcs[5].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Simon
                k = npcs[4].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Simon";
                k.whatToSay = "A game? Like… Monopoly?";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 43:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "No! I hate that game. We’re playing-";
                k.speak();
                break;
            case 44:
                //exit Simon
                k = npcs[4].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Rich
                k = npcs[5].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Rich";
                k.whatToSay = "Badminton?";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 45:
                //exit Rich
                k = npcs[5].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Nona
                k = npcs[1].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Nona";
                k.whatToSay = "Trivia?";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 46:
                //exit Nona
                k = npcs[1].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Bebe";
                k.whatToSay = "Parcheesi?";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 47:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "No no no! Let me say it in Spanish: No! We’re playing a special game I like to call the Butterfly Game!";
                k.speak();
                break;
            case 48:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "The Butterfly Game?";
                k.speak();
                break;
            case 49:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "Heehee, I’m glad you asked, Damien. Just like before, I’m going to have you go through a series of puzzle rooms. Each of those rooms holds the key to the next room. At the very end, you’ll find the Butterfly Key which will unlock the Butterfly Door. Then, you’ll be able to leave.";
                k.speak();
                break;
            case 50:
                //exit Bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Nona
                k = npcs[1].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Nona";
                k.whatToSay = "How many rooms are there?";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 51:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "That's a secret. Heehee.";
                k.speak();
                break;
            case 52:
                //exit Nona
                k = npcs[1].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Phil
                k = npcs[0].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Phil";
                k.whatToSay = "Will we be given food or water?";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 53:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "Sorry. I’m a terrible cook. I could never make edible food for you.";
                k.speak();
                break;
            case 54:
                k = npcs[0].GetComponent<NpcScript>();
                k.name = "Phil";
                k.whatToSay = "Tch.";
                k.speak();
                break;
            case 55:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "Of course, there’s another way out.";
                k.speak();
                break;
            case 56:
                //exit Phil
                k = npcs[0].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Bebe";
                k.whatToSay = "Well, spit it out. My face is too pretty for these stupid puzzles.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 57:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "Well, there would be no point in a game with only one player. It would be so boring. So, if there is only one of you left, they could go.";
                k.speak();
                break;
            case 58:
                //exit Bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Nona
                k = npcs[1].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Nona";
                k.whatToSay = "Wait, you don't mean...";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 59:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "That’s right. If six of you die, the seventh one is allowed to leave. Whether that be accidents, murder, or if the others starve to death. The great thing about the Butterfly Game is that it can go so many ways! Although, I hope it doesn’t come to murder. I would hate to see one of you dead.";
                k.speak();
                break;
            case 60:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(We all stood there frozen. The air became tense. As soon as the thought of murder entered our brains, we became immediately distrustful of each other.)";
                k.speak();
                break;
            case 61:
                //exit nona
                k = npcs[1].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.moveLeftSide();
                k.appear();
                k.name = "Bebe";
                k.whatToSay = "N-No! Don’t say that! This all just a prank, right!? I’m being punked by one of my other famous friends! You’re all just actors! Whatever they’re paying you, I’ll pay double to end this right now!";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 62:
                //exit playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Simon
                k = npcs[4].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Simon";
                k.whatToSay = "I would love to take you up on that, but I’m not an actor.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 63:
                //exit Simon
                k = npcs[4].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();

                //enter Playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Playtime";
                k.whatToSay = "Sorry, this is all real. This is a very real game. Oh! There is something I forgot to mention! There are two types of rooms. Single rooms like the classroom one you did and group rooms which you’ll all do together. The next one is a group room in the-";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 64:
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Bebe";
                k.whatToSay = "No way! No way I’m playin this sick game you little brat. If anyone here is dying, it’s gonna be you!";
                k.speak();
                break;
            case 65:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(At that moment, Bebe lunged for Playtime and quickly pinned her to the ground. I can feel her murderous intent from here.)";
                k.speak();
                break;
            case 66:
                k = npcs[2].GetComponent<NpcScript>();
                k.name = "Bebe";
                k.whatToSay = "Now you better let us out of here before I take your other eye out, you little freak!";
                k.speak();
                break;
            case 67:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "Aw, Bebe. That’s not a very good idea.";
                k.speak();
                break;
            case 68:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(At that moment, two automated machine guns descended from the ceiling and aimed directly at Bebe. She immediately jumped back.)";
                k.speak();

                k = npcs[2].GetComponent<NpcScript>();
                k.disappearInstant();
                k.moveOutScene();
                break;
            case 69:
                k = npcs[6].GetComponent<NpcScript>();
                k.name = "Playtime";
                k.whatToSay = "Well, now that you know that violence against a little girl is a bad idea, let me show you to the group room. The library!";
                k.speak();
                break;
            case 70:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(Playtime skips up the stairs and we skittishly follow her. Nona and Phil help a dazed Bebe off the floor. We see Playtime at the top of the stairs in front of some huge doors.)";
                k.speak();

                //exit playtime temporaraly
                k = npcs[6].GetComponent<NpcScript>();
                k.disappear();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 71:
                //enter playtime again
                k = npcs[6].GetComponent<NpcScript>();
                k.appear();
                k.name = "Playtime";
                k.whatToSay = "Your next puzzle is in there! Also, I made them myself! So you can praise me for my intelligence later! Also, you’re allowed to come and go as you please. But nothing out here will help you in there so don’t get any funny ideas. Well, it’s time for me to say goodbye for now!";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 72:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(She walks away and goes through another door. I hear it lock.)";
                k.speak();

                //exit playtime
                k = npcs[6].GetComponent<NpcScript>();
                k.disappear();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 73:
                //move playtime out of scene
                k = npcs[6].GetComponent<NpcScript>();
                k.moveOutScene();

                //enter bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.moveRightSide();
                k.appear();
                k.name = "Bebe";
                k.whatToSay = "I g-guess we should go in.";
                k.speak();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 74:
                k = narrator.GetComponent<NpcScript>();
                k.name = "Damien";
                k.whatToSay = "(Bebe was the first one in. The rest of us looked at each other. We were unsure of what to do but it looks like we don’t have a choice. I reluctantly push open the door.)";
                k.speak();

                //exit bebe
                k = npcs[2].GetComponent<NpcScript>();
                k.disappear();

                canChange = false;
                if (k.getAlpha() >= 1f)
                {
                    canChange = true;
                }
                break;
            case 75:
                //transition

                //switcher.GetComponent<contextSwitch>().setMode(contextSwitch.EXPLORE_MODE);
                break;
            case 76:
                k = narrator.GetComponent<NpcScript>();
                k.name = "";
                k.whatToSay = "End of chapter one. Stay tuned for the continuation in the future.";
                k.speak();
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

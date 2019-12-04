using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcScript : MonoBehaviour
{
    public string name = "Default-kun";
    public string whatToSay = "Hi. Im default.";
    public GameObject transparentMask = null;

    public Sprite[] sprites;

    private GameObject namebox;
    private GameObject nameboxTextField;

    private GameObject textbox;
    private GameObject textboxTextField;

    public bool canSee = false;
    public float thisAlpha = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.Find("FrontCanvas/Textbox");
        textboxTextField = GameObject.Find("FrontCanvas/Textbox/Text");

        namebox = GameObject.Find("FrontCanvas/Namebox");
        nameboxTextField = GameObject.Find("FrontCanvas/Namebox/Text");

    }

    public void speak()
    {
        Text field = nameboxTextField.GetComponent<Text>();
        field.text = name;

        field = textboxTextField.GetComponent<Text>();
        field.text = whatToSay;
    }

    public void moveLeftSide()
    {
        Transform t = GameObject.Find("VNMode/LeftSideTransform").transform;
        this.transform.position = t.position;
        this.transform.rotation = t.rotation;
        transparentMask = GameObject.Find("VNMode/FrontCanvas/LeftTransMask");
    }

    public void moveRightSide()
    {
        Transform t = GameObject.Find("VNMode/RightSideTransform").transform;
        this.transform.position = t.position;
        this.transform.rotation = t.rotation;

        transparentMask = GameObject.Find("VNMode/FrontCanvas/RightTransMask");
    }

    public void moveOutScene()
    {
        transform.position = new Vector3(9999f, 9999f, 9999f);
        transparentMask = null;
    }

    public bool isVisible()
    {
        return canSee;
    }
    public void appear()
    {
        canSee = true;
    }

    public void disappear()
    {
        canSee = false;
    }

    public void disappearInstant()
    {
        canSee = false;
        thisAlpha = 1f;
        if (transparentMask != null)
        {
            RawImage k = transparentMask.GetComponent<RawImage>();

            if (k != null)
            {
                k.color = new Color(k.color.r, k.color.g, k.color.b, thisAlpha);
            }
        }
    }

    public void appearInstant()
    {
        canSee = true;
        thisAlpha = 0f;
        if (transparentMask != null)
        {
            RawImage k = transparentMask.GetComponent<RawImage>();

            if (k != null)
            {
                k.color = new Color(k.color.r, k.color.g, k.color.b, thisAlpha);
            }
        }
    }

    public float getAlpha()
    {
        return 1f-thisAlpha;
    }

    public void changeSprite(int k)
    {
        /*
        Image n = GetComponent<Image>();
        n.sprite = sprites[k];
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (transparentMask != null)
        {
            if (canSee == false)
            {
                RawImage k = transparentMask.GetComponent<RawImage>();

                if (k != null)
                {
                    thisAlpha += 1f * Time.deltaTime;
                    if (thisAlpha >= 1)
                    {
                        thisAlpha = 1;
                    }

                    k.color = new Color(k.color.r, k.color.g, k.color.b, thisAlpha);
                }
            }
            else
            {
                RawImage k = transparentMask.GetComponent<RawImage>();

                if (k != null)
                {
                    thisAlpha -= 1f * Time.deltaTime;
                    if (thisAlpha <= 0)
                    {
                        thisAlpha = 0;
                    }

                    k.color = new Color(k.color.r, k.color.g, k.color.b, thisAlpha);
                }
            }
        }
    }
}

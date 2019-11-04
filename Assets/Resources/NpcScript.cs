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
                    float newAlpha = k.color.a + 0.1f;
                    if (newAlpha >= 1)
                    {
                        newAlpha = 1;
                    }

                    k.color = new Color(k.color.r, k.color.g, k.color.b, newAlpha);
                }
            }
            else
            {
                RawImage k = transparentMask.GetComponent<RawImage>();

                if (k != null)
                {
                    float newAlpha = k.color.a - 0.1f;
                    if (newAlpha <= 0)
                    {
                        newAlpha = 0;
                    }

                    k.color = new Color(k.color.r, k.color.g, k.color.b, newAlpha);
                }
            }
        }
    }
}

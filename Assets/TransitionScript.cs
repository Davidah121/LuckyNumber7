using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    private bool canSee = false;
    // Start is called before the first frame update
    void Start()
    {
        
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

        Image k = GetComponent<Image>();

        if (k != null)
        {
            float newAlpha = 0f;
            k.color = new Color(k.color.r, k.color.g, k.color.b, newAlpha);
        }
    }

    public void appearInstant()
    {
        canSee = true;
        Image k = GetComponent<Image>();

        if (k != null)
        {
            float newAlpha = 1f;
            k.color = new Color(k.color.r, k.color.g, k.color.b, newAlpha);
        }
    }

    public float getAlpha()
    {
        Image k = GetComponent<Image>();
        return k.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSee == true)
        {
            Image k = GetComponent<Image>();

            if (k != null)
            {
                float newAlpha = k.color.a + 1f * Time.deltaTime;
                if (newAlpha >= 1)
                {
                    newAlpha = 1;
                }

                k.color = new Color(k.color.r, k.color.g, k.color.b, newAlpha);
            }
        }
        else
        {
            Image k = GetComponent<Image>();

            if (k != null)
            {
                float newAlpha = k.color.a - 1f * Time.deltaTime;
                if (newAlpha <= 0)
                {
                    newAlpha = 0;
                }

                k.color = new Color(k.color.r, k.color.g, k.color.b, newAlpha);
            }
        }
    }
}

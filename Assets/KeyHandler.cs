using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHandler : MonoBehaviour
{
    public GameObject keyboard;
    public GameObject door;
    public AudioClip yes;
    public AudioClip no;
    AudioSource soundPlayer;
    public string currentstuff;
    public InputField inputPlace;
    public string solution;

    void Start()
    {
        soundPlayer = door.GetComponent<AudioSource>();
    }

    void Update()
    {
        currentstuff = inputPlace.text;
    }

    public void test()
    {
        if (currentstuff.ToUpper() == solution)
        {
            door.GetComponent<doorInt>().unlocked = true;
            soundPlayer.PlayOneShot(yes);
            keyboard.SetActive(false);
        }
        else
        {
            soundPlayer.PlayOneShot(no);
        }
    }
}

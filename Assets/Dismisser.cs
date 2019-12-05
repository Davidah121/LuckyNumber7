using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dismisser : MonoBehaviour {
    public GameObject me;
    public void Start()
    {
        me.SetActive(false);
    }
    public void dismiss()
    {
        me.SetActive(false);
    }
}

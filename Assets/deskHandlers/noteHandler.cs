using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteHandler : MonoBehaviour, interactable {
    public GameObject note;
	void Start () {
	}
    public void interact()
    {
        Debug.Log("note called");
        note.SetActive(true);
        note.SetActive(true);
    }

    public void interact(int itemcode)
    {
        //placeholder that does nothing
    }

}

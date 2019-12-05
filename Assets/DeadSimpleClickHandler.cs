using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSimpleClickHandler : MonoBehaviour {
    public GameObject camObj;
    public Camera camCam;
    public int currentItemCode = 0;
	// Use this for initialization
	void Start () {
        camCam = camObj.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;

            if(Physics.Raycast(ray, out h))
            {
                Debug.Log("Mouse down hit " + h.collider.name);
                if (h.collider.gameObject.tag == "int") //interactable tag
                {
                    if (currentItemCode != 0)
                    {
                        h.collider.GetComponent<interactable>().interact(currentItemCode);
                    }
                    else h.collider.gameObject.GetComponent<interactable>().interact();
                    currentItemCode = 0;
                }
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSimpleCameraRotate : MonoBehaviour {

    Transform mainCam;
	// Use this for initialization
	void Start () {
        mainCam = GetComponent<Transform>();
	}
	
    public void turnRight()
    {
        mainCam.Rotate(0, 90, 0);
    }

    public void turnLeft()
    {
        mainCam.Rotate(0, -90, 0);
    }
	// Update is called once per frame
	void Update () {
        bool left = Input.GetKeyDown("left");
        if (left) turnLeft();
	}
}

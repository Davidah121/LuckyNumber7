using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryController : MonoBehaviour
{
    public bool hasWindKey = false;
    public GameObject windKeyObj;
    public bool hasSpool = false;
    public GameObject spoolObj;
    public bool hasInk = false;
    public GameObject inkObj;
    public bool hasInkySpool = false;
    public GameObject inkySpool;

    // Update is called once per frame
    void Update()
    {
        if (hasWindKey) windKeyObj.SetActive(true);
        else windKeyObj.SetActive(false);
        if (hasSpool) spoolObj.SetActive(true);
        else spoolObj.SetActive(false);
        if (hasInk) inkObj.SetActive(true);
        else inkObj.SetActive(false);
        if (hasInkySpool) inkySpool.SetActive(true);
        else inkySpool.SetActive(false);
    }
}

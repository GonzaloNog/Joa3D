using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCam : MonoBehaviour
{
    public int camID;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
            GameManager.instance.ChangeCam(camID);
    }
}

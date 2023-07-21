using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderLogic : MonoBehaviour
{
    private Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "cilindro" || collision.gameObject.tag == "player")
        {
            rig.useGravity = true;
        }
    }
}

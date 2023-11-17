using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderOutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("player"))
        {
            other.GetComponent<sphere>().OutOfBounds = true;
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class martillo : MonoBehaviour
{
    public Animator anim;

    private void Start() 
    {
        this.anim.speed = 0;
    }
    public void StartAnim()
    {
        this.anim.speed = 1; 
    }
    
}

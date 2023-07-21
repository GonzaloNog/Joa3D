using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sphere : MonoBehaviour
{
    public Material material;
    public MeshRenderer meshRenderer;
    public GameObject muro;

    //audio
    public AudioSource col;
    public AudioSource pin;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == muro) 
        {
            Color color = new(Random.value, Random.value, Random.value);
            meshRenderer.material.color = color;
        }

        //audio
        if (collision.gameObject.tag == "cilindro")
        {
            Debug.Log("cilindro");
            col.Play();
        }
        if (collision.gameObject.tag == "suelo")
        {
            Debug.Log("suelo");
            pin.Play();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
    }
}
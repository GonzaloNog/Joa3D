using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sphere : MonoBehaviour
{
    public Material material;
    public MeshRenderer meshRenderer;
    public MeshRenderer meshren2;
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
            Color color = new(Random.value, Random.value, Random.value);
            meshren2.material.color = color;
            Debug.Log("cilindro");
            col.Play();
        }
        if (collision.gameObject.tag == "suelo")
        {
            Debug.Log(collision.relativeVelocity);
            pin.volume = (collision.relativeVelocity.y / 100) + 0.05f;
            pin.Play();
        }
    }
}
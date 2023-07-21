using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sphere : MonoBehaviour
{
    public GameObject muro;

    //audio
    public AudioSource col;
    public AudioSource pin;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == muro) 
        {
            Color color = new(Random.value, Random.value, Random.value);
            collision.gameObject.GetComponent<MeshRenderer>().material.color = color;
            //meshRenderer.material.color = color;
        }

        //audio
        if (collision.gameObject.tag == "cilindro")
        {
            Color color = new(Random.value, Random.value, Random.value);
            collision.gameObject.GetComponent<MeshRenderer>().material.color = color;
            //Debug.Log("cilindro");
            col.Play();
        }
        if (collision.gameObject.tag == "suelo")
        {
            //Debug.Log(collision.relativeVelocity);
            pin.volume = (collision.relativeVelocity.y / 100) + 0.05f;
            pin.Play();
        }
    }
}
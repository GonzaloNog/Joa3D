using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class sphere : MonoBehaviour
{
    public GameObject muro;
    private int puntos;
    public AudioSource pin;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

        }
        if (Input.GetKey(KeyCode.Space))
        { this.GetComponent<Rigidbody>().useGravity = true; }
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
        if (collision.gameObject == muro || collision.gameObject.CompareTag("cilindro")) 
        {
            Color color = new(Random.value, Random.value, Random.value);
            collision.gameObject.GetComponent<MeshRenderer>().material.color = color;
        }
        if (collision.gameObject.CompareTag("cilindro") && collision.gameObject.GetComponent<cylinderLogic>().GetColNum() == 0)
        {
            puntos++;
        }

        if (collision.gameObject.CompareTag("suelo"))
        {
            pin.volume = (ForceCalc(collision) / 100) + 0.05f;
            pin.Play();
        }
    }
    public int GetPuntos()
    { return puntos; }
    private float ForceCalc(Collision collision)
    {
        float[] xyz = new float[] { collision.relativeVelocity.x, collision.relativeVelocity.y, collision.relativeVelocity.z };
        float velocidad = xyz.Max();
        float masa = this.GetComponent<Rigidbody>().mass;
        float fuerza = velocidad * masa;
        if (fuerza < 0)
        { fuerza = -fuerza; }
        return fuerza;
    }
}
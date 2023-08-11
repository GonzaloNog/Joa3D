using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class sphere : MonoBehaviour
{
    public GameObject muro;
    private int puntos;
    public AudioSource pin;
    private Vector3 saveStartPosition;
    public Material[] skins;

    public void Start()
    {
        saveStartPosition = this.transform.position;
        GetComponent<MeshRenderer>().material = skins[GameManager.instance.skin];
    }
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
    public void Soltar()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
    }    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == muro || collision.gameObject.CompareTag("cilindro")) 
        {
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
        float velocidad = collision.relativeVelocity.magnitude;
        float masa = this.GetComponent<Rigidbody>().mass;
        float fuerza = velocidad * masa;
        return fuerza;
    }
    private void OnColisionEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "wall")
        {
            this.transform.position = saveStartPosition;
            Debug.Log("HOLA");
        }
            
    }
}
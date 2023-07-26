using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class sphere : MonoBehaviour
{
    public GameObject muro;
    private int puntos;
    public AudioSource pin;
    public float StartPoint;
    public bool move;

    private void Start()
    {
        move = false;
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
        if (Input.GetMouseButton(0) && move)
        {
            // Obtener la posición del mouse en el mundo
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = StartPoint; // Asegurarse de que la Z esté en una posición adecuada en el mundo
                Vector3 targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);

                // Mover el objeto hacia la posición del mouse
                transform.position = targetPosition;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == muro || collision.gameObject.CompareTag("cilindro")) 
        {
            Color color = new(Random.value, Random.value, Random.value);
            collision.gameObject.GetComponent<MeshRenderer>().material.color = color;
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
    private void OnMouseEnter()
    {
        move = true;
    }
    private void OnMouseExit()
    {
        move = false;
    }

}
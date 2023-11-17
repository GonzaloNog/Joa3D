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
    public bool OutOfBounds;
    public bool still;
    float mag;
    float i;

    public void Start()
    {
        saveStartPosition = this.transform.position;
        GetComponent<MeshRenderer>().material = skins[ConfigManager.instance.skin];
        mag = this.GetComponent<Rigidbody>().velocity.magnitude;
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
        }
        if (Input.GetKey(KeyCode.Space))
        { StartCoroutine(Soltar()); }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
        }
        if(LevelManager.instance.gameStarted) StillCheck();
        print(mag);
    }
    public IEnumerator Soltar()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1);
        LevelManager.instance.gameStarted = true;
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
    private void StillCheck()
    {
        bool stillCheck;
        if (mag < 0.01) {stillCheck = true;}
        else 
        {
            stillCheck = false;
            still = false;
        }
        while (stillCheck == true)
        {
            i+= Time.deltaTime;
            if(i >= 2)
            {
                still = true;
                stillCheck = false;
                i = 0;
            }
        }
    }
}
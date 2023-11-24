using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class sphere : MonoBehaviour
{
    public GameObject muro;
    [SerializeField]
    private int puntos;
    public AudioSource pin;
    private Vector3 saveStartPosition;
    public Material[] skins;
    public bool OutOfBounds;
    public bool still;
    public Rigidbody rb;
    public float i;
    private bool isGrounded;

    public void Start()
    {
        i = 5;
        saveStartPosition = this.transform.position;
        GetComponent<MeshRenderer>().material = skins[ConfigManager.instance.skin];
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
        if (LevelManager.instance.gameStarted) IsStill();
        if (isGrounded && IsStill()) OnGrounded(); else i = 5;
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
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = true;
        }   
    }
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = false;
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
    private void OnGrounded()
    {
        i -= Time.deltaTime;
        if (i <= 0) still = true;
    }
    public bool IsStill()
    {
        if (rb.velocity.magnitude < .5) 
        return true;
        else return false;    
    }
}

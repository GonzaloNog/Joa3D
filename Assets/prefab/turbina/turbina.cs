using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class turbina : MonoBehaviour
{
    bool prender = true;
    public int fuerza;
    public GameObject banda;
    private void Update() 
    {
        Indicador();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && prender)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            Vector3 vec3 = -this.transform.forward;

            rb.AddForce(vec3*fuerza);
        }
    }
    public void Toggle()
    {
        prender = !prender;
    }
    public void StartBlink(float apagar, float prender)
    {
        StartCoroutine(Timer(apagar, prender));
    }
    private void Indicador()
    {
        Material mat = banda.GetComponent<Renderer>().material;
        
        if (prender)
            mat.SetColor("_EmissionColor", Color.red);
        else
            mat.SetColor("_EmissionColor", Color.black);
    }
    IEnumerator Timer(float apagar, float prender)
    {
        Toggle();
        yield return new WaitForSeconds(apagar);

        Toggle();
        yield return new WaitForSeconds(prender);

        StartCoroutine(Timer(apagar,prender));
    }
}

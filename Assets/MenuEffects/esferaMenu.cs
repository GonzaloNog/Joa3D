using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class esferaMenu : MonoBehaviour
{
    private Rigidbody rb;
    public MeshRenderer meshren;
    public float directionForce = 1;
    public float downForce = 10;
    private float time = 0;
    public float destroySec = 3;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        StartSpawn();
    }
    private void Update()
    {
        time = time+Time.deltaTime;
        if (time >= destroySec)
        {
            effectManager.effmgr.DestroySphere();
            Destroy(this.gameObject);
        }
    }
    public void StartSpawn()
    {
        Color color = new(Random.value, Random.value, Random.value);
        float metallic = Random.Range(0, 1);
        float smoothness = Random.Range(0, 1);
        meshren.material.color = color;
        meshren.material.SetFloat("Metallic", metallic);
        meshren.material.SetFloat("Smoothness", smoothness);
        float dirforcemult = directionForce + Random.Range(0,3);
        float downforcemult = downForce      + Random.Range(0,3);
        Vector3 direction = Random.insideUnitCircle.normalized;
        rb.AddForce(direction * dirforcemult, ForceMode.VelocityChange);
        rb.AddForce(Vector3.down * downforcemult, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            Vector3 direction = Random.insideUnitCircle.normalized;
            float ranmult = directionForce + Random.Range(0, 3);
            rb.AddForce(direction * ranmult, ForceMode.VelocityChange);
        }
    }
}
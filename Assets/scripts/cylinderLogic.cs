using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cylinderLogic : MonoBehaviour
{
    private Rigidbody rig;
    private AudioSource audiosource;
    public AudioClip[] audioclip;
    private bool point;
    int audioplayed = 0;
    int colisionesJugador = 0;
    void Start()
    {
        point = false;
        rig = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("cilindro") || collision.collider.tag == "player") && !point)
        {
            GameManager.instance.puntos++;
            GameManager.instance.UI.UpdatePuntos();
            point = true;
        }
        if (collision.collider.tag == "player")
            colisionesJugador++;
        AudioStuffs(collision);
    }
    public int GetColNum()
    { 
        return colisionesJugador;
    }
    public void AudioStuffs(Collision collision)
    {
        int clipID = Random.Range(0, audioclip.Length);
        audiosource.clip = audioclip[clipID];
        if (collision.gameObject.tag == "cilindro" || collision.gameObject.tag == "player")
        {
            audiosource.volume = (ForceCalc(collision) / 100) + 0.05f;
            if (audiosource.volume > .05f)
                audiosource.volume = .05f;
            rig.useGravity = true;
            if (audioplayed <= 2 && !audiosource.isPlaying)
            {
                audiosource.Play();
                audioplayed++;
            }
        }
    }
    private float ForceCalc(Collision collision)
    {
        //Que es relativeVelocity, Vector3
        float[] xyz = new float[] {collision.relativeVelocity.x, collision.relativeVelocity.y,collision.relativeVelocity.z};
        float velocidad = xyz.Max();
        float masa = collision.rigidbody.mass;
        float fuerza = velocidad * masa;
        if (fuerza < 0)
        {fuerza *= -1;}
        return fuerza;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager UI;
    public Camera[] camList;
    public int skin;
    public sphere player;
    public int puntos;
    public bool pause;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        pause = false;
        skin = 0;
        puntos = 0;
    }
    public void SetAudio()
    {
        AudioListener.volume = UI.GetAudioSlider();
    }
    public sphere GetPlayer() { return  player; }
    public void ChangeCam(int cam)
    {
        Debug.Log(cam);
        for(int a = 0; a < camList.Length;a++)
        {
            camList[a].gameObject.SetActive(false);
        }
        camList[cam].gameObject.SetActive(true);
    }
}

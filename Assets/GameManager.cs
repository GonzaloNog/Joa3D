using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera[] camList;
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
        //ChangeCam(0);
    }
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

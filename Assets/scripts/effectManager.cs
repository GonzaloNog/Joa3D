using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class effectManager : MonoBehaviour
{
    public static effectManager effmgr;
    public spawnBallMenu spawner;
    public GameObject[] prefabHit;
    private void Start()
    {
        if (effmgr == null)
        { effmgr = this; }
    }
    public void DestroySphere()
    {
        //image.SetActive(true);
        int RanHit = Random.Range(0, prefabHit.Length);
        Instantiate(prefabHit[RanHit], spawner.prefabInsanciado.transform.position, spawner.prefabInsanciado.transform.rotation);
        Debug.Log("destroysphere");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBallMenu : MonoBehaviour
{
    public float timer = 1;
    float i=0;
    public GameObject prefab;
    public GameObject prefabInsanciado;
    void Update()
    {
        i = i + Time.deltaTime;
        if (i >= timer)
        {
            i = 0;
            SpawnBall();
        }
    }
    void SpawnBall()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-1,1),5,Random.Range(-11, 11));
        prefabInsanciado = Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}
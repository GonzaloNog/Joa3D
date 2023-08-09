using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderArranque : MonoBehaviour
{
    public GameObject startpos;
    public GameObject sphere;
    private void OnCollisionExit(Collision collision)
    {
        salioAreaArranque();

    }
    public void salioAreaArranque()
    {
        sphere.gameObject.transform.position = startpos.gameObject.transform.position;
    }

}

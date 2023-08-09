using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void BotonesMenu (string _string)
    {
        switch (_string)
        {
            case "play":
                SceneManager.LoadScene("nivel_0");
                break;
            case "quit":
                Application.Quit();
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject layout;
    public GameObject skinsBack;
    public GameObject options;
    public GameObject skinSelect;
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
    public void ToggleMenuSkins()
    {
        layout.SetActive(!layout.activeSelf);
        skinsBack.SetActive(!skinsBack.activeSelf);
        options.SetActive(!options.activeSelf);
        skinSelect.SetActive(!skinSelect.activeSelf);
    }
    public void SetSkin(int skinID)
    {
        switch (skinID)
        {
            case 1:
            
            break;
            case 2:
            
            break;
            default:
            print("Skin no encontrada");
            break;
        }
    }
}

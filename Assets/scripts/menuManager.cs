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
    public GameObject menuNiveles;
    public void BotonesMenu (string _string)
    {
        switch (_string)
        {
            case "quit":
                Application.Quit();
                break;
        }
    }
    public void LevelChange(string nivel)
    {
        switch(nivel)
        {
            case "1":
            SceneManager.LoadScene("nivel_1");
            break;
            case "2":
            SceneManager.LoadScene("nivel_2");
            break;
            case "3":
            SceneManager.LoadScene("nivel_3");
            break;
            case "4":
            SceneManager.LoadScene("nivel_4");
            break;
            case "5":
            SceneManager.LoadScene("nivel_5");
            break;
            case "6":
            SceneManager.LoadScene("nivel_6");
            break;
            case "7":
            SceneManager.LoadScene("nivel_7");
            break;
            case "8":
            SceneManager.LoadScene("nivel_8");
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
    public void ToggleNivelesMenu()
    {
        layout.SetActive(!layout.activeSelf);
        menuNiveles.SetActive(!menuNiveles.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject PuntosUI;
    private TextMeshProUGUI puntostext;

    private void Start()
    {
    }
    private void Update()
    {
            UpdatePuntos();
    }
    public void UpdatePuntos()
    {
        puntostext = PuntosUI.GetComponent<TextMeshProUGUI>();
        int puntos = GameManager.instance.GetPlayer().GetPuntos();
        puntostext.text = puntos.ToString();
    }
    public void MenuPrincipalBotones(string boton)
    {
        switch (boton)
        {
            case "play":
                SceneManager.LoadScene("nivel_0");
                break;
            case "quit":
                break;
        }
    }
}
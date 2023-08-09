using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Slider slidervolumen;
    public GameObject PuntosUI;
    public GameObject pausaMenu;
    private TextMeshProUGUI puntostext;


    public float GetAudioSlider()
    {
        return slidervolumen.value;
    }
    private void Start()
    {
        UpdatePuntos();
    }
    public void UpdatePuntos()
    {
        puntostext = PuntosUI.GetComponent<TextMeshProUGUI>();
        int puntos = GameManager.instance.puntos;
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
    public void Pausa()
    {
        pausaMenu.SetActive(!pausaMenu.activeSelf);
    }
}
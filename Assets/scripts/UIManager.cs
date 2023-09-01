using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Slider slidervolumen;
    public GameObject PuntosUI;
    public GameObject pausaMenu;
    private TextMeshProUGUI puntostext;
    public GameObject lanzar;
    public GameObject exitBoton;

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu_principal");
    }
    public float GetAudioSlider()
    {
        return slidervolumen.value;
    }
    private void Start()
    {
        UpdatePuntos();
        slidervolumen.value = AudioListener.volume;
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
        if (!pausaMenu.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pausaMenu.SetActive(!pausaMenu.activeSelf);
        lanzar.SetActive(!pausaMenu.activeSelf);
        exitBoton.SetActive(!exitBoton.activeSelf);
        GameManager.instance.pause = pausaMenu.activeSelf;
    }
}
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
    public GameObject gameOverUI;
    public GameObject[] estrellasUI;

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
    public void GameOver(int estrellas)
    {
        gameOverUI.SetActive(true);
        //StartCoroutine(ActivarEstrellas(estrellas));
    }
    IEnumerator ActivarEstrellas(int a)
    {
        print("estrellas = " + a);
        for(int i = 0; i<estrellasUI.Length; i++)
        {
            print(i);
            estrellasUI[i].SetActive(false);
        }
        for(int i = 0; i>a+1; i++)
        {
            print(i);
            yield return new WaitForSeconds(0.5f);
            estrellasUI[i].SetActive(true);
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject[] turbinas;
    public GameObject[] martillos;
    public float apagarDuracion;
    public float prenderDuracion;
    public float martilloDelay;

    public bool gameOver;
    public bool gameStarted;
    private sphere player;
    public int estrellas;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else 
            Destroy(this);
    }
    void Start()
    {
        StartCoroutine(StartTurbinas());
        StartCoroutine(StartMartillos());
        player = GameManager.instance.player;
    }
    private void Update() 
    {
        if (gameStarted) GameOverCheck();
    }
    IEnumerator StartTurbinas()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i<turbinas.Length; i++)
        {
            turbina script = turbinas[i].GetComponent<turbina>();

            script.StartBlink(2,1);
            yield return new WaitForSeconds(1);
        }

    }
    IEnumerator StartMartillos()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i<martillos.Length; i++)
        {
            martillo script = martillos[i].GetComponent<martillo>();

            script.StartAnim();
            yield return new WaitForSeconds(martilloDelay);
        }
    }

    private void GameOverCheck()
    {
        if (player.OutOfBounds || player.still)
        {
            GameOver();
        }  
    }
    private void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0.00001f;
        GameManager.instance.UI.GameOver(Estrellas());
    }
    private int Estrellas()
    {
        int puntos = player.GetPuntos();
        if (puntos == 0)
        {
            estrellas = 0;
        }
        else if (puntos <= 5)
        {
            estrellas = 1;
        }
        else if (puntos < 10)
        {
            estrellas = 2;
        }
        else if (puntos == 10)
        {
            estrellas = 3;
        }
        print(estrellas);
        return estrellas;
    }
}

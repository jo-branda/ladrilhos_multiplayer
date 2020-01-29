using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_end : MonoBehaviour
{
    public int pontos;
    public int win;
    public string reason;
    public Text Txt_Estado;
    public Text Txt_Pontos;
    public Text Txt_Reason;

    // Start is called before the first frame update
    void Start()
    {
        atualEstado();
        atualPontos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changemenuscene(string scenename)
    {
       SceneManager.LoadScene(scenename);
    }

    public void atualEstado()
    {
        if (this.win == 1)
        {
            //Ganhou
            Txt_Estado.text = "Parabéns! É o vencedor do jogo.";
        }
        else if (win == 0)
        {
            //Perdeu
            Txt_Estado.text = "Oh! Infelizmente perdeu, mas vai conseguir ganhar se continuar a praticar.";
        }
    }

    public void atualPontos()
    {
        //Recebe os pontos da jogada e adiciona à pontuação atual
        Txt_Pontos.text = "" + this.pontos;
        Txt_Reason.text = "" + this.reason;
    }

    void OnEnable()
    {
        this.pontos = PlayerPrefs.GetInt("points");
        this.win = PlayerPrefs.GetInt("isWinner");
        this.reason = PlayerPrefs.GetString("reason");
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuStart : MonoBehaviour
{
    private int sons = 1;
    private int musica = 1;
    private int dicas = 1;

    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    public void OnDisable()
    {
        PlayerPrefs.SetInt("sons", this.sons);
        PlayerPrefs.SetInt("musica", this.musica);
        PlayerPrefs.SetInt("dicas", this.dicas);
    }
}

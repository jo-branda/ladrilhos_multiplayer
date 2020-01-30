using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    private int sons;
    private int musica;
    private int dicas;

    public GameObject btnSons;
    public GameObject btnMusica;
    public GameObject btnDicas;

    public Image on;
    public Image off;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOnOffS(int i)
    {
        //Se for zero está desligado e viceversa
        if(i == 0)
        {
            //btnSons.setComponent < Image > = on;
        }
        else if(i == 1)
        {

        }
    }

    public void turnOnOffM(int i)
    {
        //Se for zero está desligado e viceversa
        if (i == 0)
        {

        }
        else if (i == 1)
        {

        }
    }

    public void turnOnOffD(int i)
    {
        //Se for zero está desligado e viceversa
        if (i == 0)
        {

        }
        else if (i == 1)
        {

        }
    }

    void OnEnable()
    {
        this.sons = PlayerPrefs.GetInt("sons");
        this.musica = PlayerPrefs.GetInt("musica");
        this.dicas = PlayerPrefs.GetInt("dicas");
    }

    public void OnDisable()
    {
        PlayerPrefs.SetInt("sons", this.sons);
        PlayerPrefs.SetInt("musica", this.musica);
        PlayerPrefs.SetInt("dicas", this.dicas);
    }

}

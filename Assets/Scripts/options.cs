using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    private int sons;
    private int musica;
    private int dicas;
    private string adress;

    public Button btnSons;
    public Button btnMusica;
    public Button btnDicas;
    public InputField inputAdress;

    public Sprite on;
    public Sprite off;

    public GameObject popupOptions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    public void openPopup()
    {
        popupOptions.SetActive(true);
    }

    public void closePopup()
    {
        popupOptions.SetActive(false);
    }

    public void turnOnOffS()
    {
        //Se for zero está desligado e viceversa
        if(this.sons == 0)
        {
            //Liga botao
            btnSons.GetComponent<Image>().sprite = on;
            this.sons = 1;
        }
        else if(this.sons == 1)
        {
            //Desliga botao
            btnSons.GetComponent<Image>().sprite = off;
            this.sons = 0;
        }
    }

    public void turnOnOffM()
    {
        //Se for zero está desligado e viceversa
        if (this.musica == 0)
        {
            //Liga botao
            btnMusica.GetComponent<Image>().sprite = on;
            this.musica = 1;

            Debug.Log(this.musica);
        }
        else if (this.musica == 1)
        {
            //Desliga botao
            btnMusica.GetComponent<Image>().sprite = off;
            this.musica = 0;

            Debug.Log(this.musica);

        }
    }

    public void turnOnOffD()
    {
        //Se for zero está desligado e viceversa
        if (this.dicas == 0)
        {
            //Liga botao
            btnDicas.GetComponent<Image>().sprite = on;
            this.dicas = 1;
        }
        else if (this.dicas == 1)
        {
            //Desliga botao
            btnDicas.GetComponent<Image>().sprite = off;
            this.dicas = 0;
        }
    }
    public void updateAdress()
    {
        this.adress = inputAdress.text;
        Debug.Log(this.adress);
    }

    void OnEnable()
    {
        this.sons = PlayerPrefs.GetInt("sons");
        this.musica = PlayerPrefs.GetInt("musica");
        this.dicas = PlayerPrefs.GetInt("dicas");
        this.adress = PlayerPrefs.GetString("Adress");
    }

    public void OnDisable()
    {
        PlayerPrefs.SetInt("sons", this.sons);
        PlayerPrefs.SetInt("musica", this.musica);
        PlayerPrefs.SetInt("dicas", this.dicas);
        PlayerPrefs.SetString("Adress", this.adress);
    }

}

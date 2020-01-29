using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peca : MonoBehaviour
{
    private int x;
    private int y;
    private string color;
    private string form;

    public peca (int x_, int y_ , string c, string f)
    {
        this.x = x_;
        this.y = y_;
        this.color = c;
        this.form = f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string getForm
    {
        get => this.form;
        set => this.form = value;

    }
    public string getColor 
    {
        get => this.color;
        set => this.color = value;

    }
    public int getPosX
    {
        get => this.x;
        set => this.x = value;

    }
    public int getPosY
    {
        get => this.y;
        set => this.y = value;

    }


    //public bool validMove(peca p, int x, int y)
    //{
        
    //}
}

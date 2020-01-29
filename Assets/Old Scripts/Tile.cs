using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool livre;
    private int x;
    private int y;
    private peca Peca;
    
    void Start()
    {
        
    }
    public Tile(bool livre, peca p)
    {
        livre = true;
        p = null;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public peca peca_tile
    {
        get => this.Peca;
        set => this.Peca = value;

    }
    public void setFree(bool f)
    {
        this.livre = f;
    }
    public bool isFree()
    {
        return this.livre;
    }



}

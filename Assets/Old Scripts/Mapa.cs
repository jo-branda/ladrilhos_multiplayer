using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    public GameObject CubePrefab;
    public GameObject tilePrefab;
    public Vector2 mapSize;
    private List<Tile> tiles = new List<Tile>();
    private List<peca> pecas = new List<peca>(6); // Peças para jogar
    private LinkedList<peca> pecasJogadas = new LinkedList<peca>(); // Peças jogadas (Todas)
    private LinkedList<peca> jogada = new LinkedList<peca>();
    private Vector2 mouseOver;
    private Vector3 boardOffset = new Vector3(5.0f, 0, 5.0f);
    private Vector3 PecaOffset = new Vector3(0.5f, 0, 0.5f);
    private peca pecaAtual;
    private peca pecaSelecionada;
    void Start()
    {

        GenerateMap();

    }
    // Update is called once per frame
    void Update()
    {
        UpdateMouseOver();
        int _x = (int)mouseOver.x;
        int _y = (int)mouseOver.y;
        ColocaPeca(_x, _y);
        updateColors();
    }

    private void updateColors()
    {
    }

    public void GenerateMap()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                GameObject newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as GameObject;
                newTile.transform.SetParent(transform);
                Tile t = newTile.GetComponent<Tile>();
                t.getPosX = x;
                t.getPosY = y;
                tiles.Add(t);
                 
            }

        }
    }
    public void UpdateMouseOver()
    {
        if (!Camera.main)
        {
            Debug.LogError("Camera not Found");
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Mapa")))
        {
            mouseOver.x = (int)(hit.point.x - (-5.0f));
            mouseOver.y = (int)(hit.point.z - (-5.0f));
        }
        else
        {
            mouseOver.x = -1;
            mouseOver.y = -1;
        }
    }

    private void MovePeca(peca p, int x, int y)
    {
        p.transform.position = (Vector3.right * x) + (Vector3.forward * y) + boardOffset + PecaOffset;
    }
    public void ColocaPeca(int _x, int _y)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Out of Bounds
            if (_x < 0 || _x >= 10 || _y < 0 || _y >= 10)
            {
                return;
            }
            else
            {  // Switch case Peca selecionada
                Vector3 position = new Vector3(_x, 0.25f, _y) + new Vector3(-5.0f, 0, -5.0f) + new Vector3(0.5f, 0, 0.5f);
                GameObject newPeca = Instantiate(CubePrefab, position, Quaternion.identity) as GameObject;
                newPeca.transform.SetParent(transform);
                peca p = newPeca.GetComponent<peca>();
                //p.getColor = pecaSelecionada.getColor;
                //p.getForm = pecaSelecionada.getForm;
                p.getPosX = _x;
                p.getPosY = _y;
                pecasJogadas.AddLast(p);
                pecaAtual = p;
                for (int i = 0; i < tiles.Count; i++)
                {
                   if (tiles[i].getPosX == _x && tiles[i].getPosY == _y)
                    {
                        tiles[i].setFree(false);
                    }
                }
            }
        }
    }

    public void ValidMove(peca p)
    {
        
        //if (pecaAtual == null && pecasJogadas == null)
        //{
        //    //Inicio do jogo - pintar o tile do centro a verde
        //}
        for (int i = 0; i < tiles.Count; i++)
        {
            if (!tiles[i].isFree())
            {

            }
        }


    }
    public void getPoints()
    {
        // Irá contar os pontos da lista ligada
    }

    public List<Tile> getPositions()
    {
        int px = pecaAtual.getPosX;
        int py = pecaAtual.getPosY;
        List<Tile> tilesPossiveis = new List<Tile>();
        Tile center = null;
        Tile right = null;
        Tile top = null;
        Tile bottom = null;
        Tile left = null;

        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].getPosX == px && tiles[i].getPosY == py)
            {
                center = tiles[i];
                right = SearchTile(center.getPosX + 1, center.getPosY);
                left = SearchTile(center.getPosX - 1, center.getPosY);
                bottom = SearchTile(center.getPosX, center.getPosY - 1);
                top = SearchTile(center.getPosX, center.getPosY -1);
            }
        }
        tilesPossiveis.Add(right);
        tilesPossiveis.Add(top);
        tilesPossiveis.Add(left);
        tilesPossiveis.Add(bottom);

        return tilesPossiveis;

    }
    public Tile SearchTile(int x, int y)
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].getPosX == x && tiles[i].getPosY == y)
            {
                return tiles[i];
            }
        }
        return null;
    }
    
}

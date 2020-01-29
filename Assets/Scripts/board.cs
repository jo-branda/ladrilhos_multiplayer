using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class board : MonoBehaviour
{
    public GameObject board_tile;
    public hand hand;
    private List<GameObject> listaTiles;
    public NetWorkClient nt;
    public Text Txt_pontos;
    public Text txt_ronda;
    public int pontos;
    private int ronda;
    private string endReason;
    private bool isWinner;

    public Text Txt_Dicas;
    public Text Txt_turn;

    public baralho baralho;

    // Prefabs
    public GameObject A;
    public GameObject A00;
    public GameObject A01;
    public GameObject A02;
    public GameObject A03;
    public GameObject A04;
    public GameObject A05;

    public GameObject A10;
    public GameObject A11;
    public GameObject A12;
    public GameObject A13;
    public GameObject A14;
    public GameObject A15;

    public GameObject A20;
    public GameObject A21;
    public GameObject A22;
    public GameObject A23;
    public GameObject A24;
    public GameObject A25;

    public GameObject A30;
    public GameObject A31;
    public GameObject A32;
    public GameObject A33;
    public GameObject A34;
    public GameObject A35;

    public GameObject A40;
    public GameObject A41;
    public GameObject A42;
    public GameObject A43;
    public GameObject A44;
    public GameObject A45;

    public GameObject A50;
    public GameObject A51;
    public GameObject A52;
    public GameObject A53;
    public GameObject A54;
    public GameObject A55;

    private tile[,] _board;
    private List<tile> pecasJogadas = new List<tile>();
    private Vector2 mouseOver;
    private Vector3 boardOffset = new Vector3(5.0f, 0, 5.0f);
    private Vector3 tileOffset = new Vector3(0.5f, 0f, 0.5f);
    private GameObject pecaSelecionada;
    private tile Peca;
    public Text txt_Selecionada1;
    public Text txt_Selecionada2;
    public Text txt_Selecionada3;
    public Text txt_Selecionada4;
    public Text txt_Selecionada5;
    public Text txt_Selecionada6;

    public int ColCount
    {
        get;
        private set;
    }
    public int RowCount
    {
        get;
        private set;
    }
    public board(int rcount, int ccount)
    {
        this.ColCount = rcount;
        this.RowCount = ccount;
        this._board = new tile[rcount, ccount];
    }
    public void clearBoard()
    {
        this._board = new tile[RowCount, ColCount];
    }

    private void Start()
    {
        this.ColCount = 10;
        this.RowCount = 10;
        this._board = new tile[10, 10];
        pecasJogadas = new List<tile>();

        this.pontos = 0;
        this.ronda = 1;
        this.isWinner = false;

        listaTiles = new List<GameObject>();

        baralho = new baralho();

        listaTiles.Add(A00);
        listaTiles.Add(A01);
        listaTiles.Add(A02);
        listaTiles.Add(A03);
        listaTiles.Add(A04);
        listaTiles.Add(A05);
        listaTiles.Add(A10);
        listaTiles.Add(A11);
        listaTiles.Add(A12);
        listaTiles.Add(A13);
        listaTiles.Add(A14);
        listaTiles.Add(A15);
        listaTiles.Add(A20);
        listaTiles.Add(A21);
        listaTiles.Add(A22);
        listaTiles.Add(A23);
        listaTiles.Add(A24);
        listaTiles.Add(A25);
        listaTiles.Add(A30);
        listaTiles.Add(A31);
        listaTiles.Add(A32);
        listaTiles.Add(A33);
        listaTiles.Add(A34);
        listaTiles.Add(A35);
        listaTiles.Add(A40);
        listaTiles.Add(A41);
        listaTiles.Add(A42);
        listaTiles.Add(A43);
        listaTiles.Add(A44);
        listaTiles.Add(A45);
        listaTiles.Add(A50);
        listaTiles.Add(A51);
        listaTiles.Add(A52);
        listaTiles.Add(A53);
        listaTiles.Add(A54);
        listaTiles.Add(A55);

        hand = hand.instance;
        tiraNovasPecas();
    }
    // Update is called once per frame
    void Update()
    {
        updateBoard();
        atualPontos();
        OnGameOver();
        updateSelectedPiece();
        UpdateMouseOver();
        int _x = (int)mouseOver.x;
        int _y = (int)mouseOver.y;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!myTurn())
        {
            displayTurn("Aguarde a sua vez de jogar");
            atualTexto("");
            return;
        }
        else
        {
            displayTurn("É a sua vez de jogar!");
        }
            

        if (Input.GetMouseButtonDown(0))
        {
            
            if (pecasJogadas.Count == 0 && nt.tilesFromServer.Count == 0)
            {
                Place(Peca, _x, _y);
                
                
            }
            else
            {
                PlaceATile(Peca, _x, _y);
                
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

    public void updateSelectedPiece()
    {
        if (this.pecaSelecionada = null)
        {
            atualTexto("Escolha a peça");
        }
        else
        {
            this.pecaSelecionada = getTilebyName(hand.getSelectedCard());
            //Debug.Log(this.pecaSelecionada);
           
            this.Peca = pecaSelecionada.GetComponent<tile>();
            //Debug.Log(Peca.Name);
        }
    }

    public void PlaceATile(tile t,int _x, int _y)
    {
        if (this.pecaSelecionada == A)
        {
            atualTexto("Escolha a peça");
            return;
        }

        if (isValidPlacement(t, _x, _y))
        {
            
            Vector3 position = new Vector3(_x, 0, _y) + new Vector3(-5.0f,0,-5.0f) + new Vector3(0.5f, 0.05f, 0.5f);
            GameObject newTile = Instantiate(pecaSelecionada,position,Quaternion.identity) as GameObject;
            newTile.transform.SetParent(transform);
            _board[_x, _y] = t;
            pecasJogadas.Add(t);
            hand.Remove(pecaSelecionada);
            atualTexto("Adicione um azulejo da mesma cor ou forma que o anterior.");
            sendData(_x, _y, t.name);
            getTilebyName("A");
            limpaAtualSelecionada();
        }   

    }

    private void limpaAtualSelecionada()
    {
        txt_Selecionada1.text = "";
        txt_Selecionada2.text = "";
        txt_Selecionada3.text = "";
        txt_Selecionada4.text = "";
        txt_Selecionada5.text = "";
        txt_Selecionada6.text = "";
    }

    public bool OffBoardPosition(int row, int column)
    {
        return ((row < 0 || row >= RowCount) || (column < 0 || column >= ColCount));
    }

    public tile searchTileByPos(int row, int column)
    {
        return _board[row, column];
    }

    public tile RemoveTile(int row, int column)
    {
        tile t = _board[row, column];
        _board[row, column] = null;

        return t;
    }

    // Colocar peça sem regras (Inicio do jogo)
    public void Place (tile t, int row, int column)
    {
        if (this.pecaSelecionada == A)
        {
            atualTexto("Selecione uma peça");
            return;
        }

        // Out of bounds
        if (OffBoardPosition(row, column))
        {
            atualTexto("Fora do tabuleiro");
            return;
        }
        // Piece Already in
        if (_board[row,column] != null)
        {
            atualTexto("Já contém uma peça");
            return;
        }
        
        Vector3 position = new Vector3(row, 0, column)+ new Vector3(-5.0f, 0, -5.0f) + new Vector3(0.5f, 0.05f, 0.5f); ;
        GameObject newTile = Instantiate(pecaSelecionada, position, Quaternion.identity) as GameObject;
        newTile.transform.SetParent(transform);
        _board[row, column] = t;
        pecasJogadas.Add(t);

        Debug.Log("Colocou 1 peca");
        hand.Remove(pecaSelecionada);
        //atualPontos(5);
        atualTexto("Adicione um azulejo da mesma cor ou forma que o anterior.");
        sendData(row, column, t.name);
        getTilebyName("A");
        limpaAtualSelecionada();
    }

    public bool isValidPlacement(tile t, int row, int column)
    {
        if (this.pecaSelecionada == A)
        {
            atualTexto("Selecione uma peça");
            return false;
        }

        if (OffBoardPosition(row, column))
        {
            atualTexto("Fora do tabuleiro");
            return false; // Is out of bounds
        }

        if (_board[row,column] != null)
        {
            atualTexto("Já contém uma peça");
            return false; // Is a piece in that position
        }

        bool possibleHorizontal = (!OffBoardPosition(row, column - 1) && t.IsCompatibleWith(_board[row, column - 1])) ||
                                  (!OffBoardPosition(row, column + 1) && t.IsCompatibleWith(_board[row, column + 1]));

        bool possibleVertical = (!OffBoardPosition(row - 1, column) && t.IsCompatibleWith(_board[row - 1, column])) ||
                                (!OffBoardPosition(row + 1, column) && t.IsCompatibleWith(_board[row + 1, column]));



        if (!possibleHorizontal && !possibleVertical)
        {
            atualTexto("Não combina a peca!");
            return false;
        }



            if ((!OffBoardPosition(row, column - 1)) && ((_board[row, column - 1]) != null) && (!OffBoardPosition(row - 1, column)) && ((_board[row - 1, column]) != null)){
            if (((t.IsCompatibleWith(_board[row, column - 1])) && (!t.IsCompatibleWith(_board[row - 1, column]))) || 
                ((!t.IsCompatibleWith(_board[row, column - 1])) && (t.IsCompatibleWith(_board[row - 1, column]))))
            {
                return false;
            }
        }   

        



            if ((!OffBoardPosition(row, column - 1)) && ((_board[row, column - 1]) != null) && (!OffBoardPosition(row + 1, column)) && ((_board[row + 1, column]) != null))
            {
                if (((t.IsCompatibleWith(_board[row, column - 1])) && (!t.IsCompatibleWith(_board[row + 1, column]))) ||
                    ((!t.IsCompatibleWith(_board[row, column - 1])) && (t.IsCompatibleWith(_board[row + 1, column]))))
                {
                    return false;
                }
            }
        

        

            if ((!OffBoardPosition(row, column + 1)) && ((_board[row, column + 1]) != null) && (!OffBoardPosition(row - 1, column)) && ((_board[row - 1, column]) != null))
        {
            if (((t.IsCompatibleWith(_board[row, column + 1])) && (!t.IsCompatibleWith(_board[row - 1, column]))) ||
                ((!t.IsCompatibleWith(_board[row, column + 1])) && (t.IsCompatibleWith(_board[row - 1, column]))))
            {
                return false;
            }
        }
        



            if ((!OffBoardPosition(row, column + 1)) && ((_board[row, column + 1]) != null) && (!OffBoardPosition(row + 1, column)) && ((_board[row + 1, column]) != null))
            {
                if (((t.IsCompatibleWith(_board[row, column + 1])) && (!t.IsCompatibleWith(_board[row + 1, column]))) ||
                    ((!t.IsCompatibleWith(_board[row, column + 1])) && (t.IsCompatibleWith(_board[row + 1, column]))))
                {
                    return false;
                }
            }

        atualTexto("Muito Bem!");
        return true;
    }

    public GameObject getTilebyName(string n)
    {
        GameObject tile = A;
        for (int i = 0; i < listaTiles.Count(); i++)
        {
            if (listaTiles[i].name == n)
            {
                tile = listaTiles[i];
            }

        }
        return tile;
    }

    public void tiraNovasPecas()
    {
        Debug.Log("A recolher novas pecas");
        for (int i = 0; i < 6; i++)
        { 
            while(hand.pecas.Count < 6)
            {
                hand.Add(getTilebyName(baralho.TakePeca()));
            }
        }
    }

    public void passarVez()
    {
        nt.Emit("passa_vez");
        tiraNovasPecas();
    }
    public void sairJogo()
    {
        Debug.Log("Sair");
        var sockConn = nt;
        sockConn.disconnect();
        SceneManager.LoadScene("Menu");
    }
    public void sendData(int x, int y, string n)
    {
        InfoPeca newTile = new InfoPeca(x, y, n);
        nt.Emit("place_tile", new JSONObject(JsonUtility.ToJson(newTile)));
        //place_tile
    }       
    public void updateBoard()
    {
        //Recebe board_state[]
        List<InfoPeca> listPecas = nt.tilesFromServer;
        GameObject t;
        int row;
        int column;
        string type;
        // Para cada objecto json
        for (int i = 0; i < listPecas.Count; i++)
        {
            InfoPeca info = listPecas[i];
            row = info.x;
            column = info.y;
            type = info.tileType;
            t = getTilebyName(type);
            if(_board[row,column] == null)
            {
                Vector3 position = new Vector3(row, 0, column) + new Vector3(-5.0f, 0, -5.0f) + new Vector3(0.5f, 0.05f, 0.5f);
                GameObject newTile = Instantiate(t, position, Quaternion.identity) as GameObject;
                newTile.transform.SetParent(transform);
                _board[row, column] = t.GetComponent<tile>();
            }

        }
    }
    public bool myTurn()
    {
        return nt.myTurn;
    }
    public void updateUI()
    {
        // Update points
    }

    public void atualPontos()
    {
        //Recebe os pontos da jogada e adiciona à pontuação atual
        this.pontos = nt.myPoints;
        this.ronda = nt.currRound + 1;
        Txt_pontos.text = "Pontuação: " + (this.pontos);
        txt_ronda.text = "Ronda: " + this.ronda + "/5";
    }

    public void atualTexto(string dica)
    {
        Txt_Dicas.text = dica;
    }
    public void displayTurn(string turn)
    {
        this.Txt_turn.text = turn;
    }
    public void OnGameOver()
    {
        if (nt.gameOver)
        {
            this.isWinner = nt.Iswinner;
            this.endReason = nt.endReason;
            SceneManager.LoadScene("Endgame");
        }

    }
    public void OnDisable()
    {
        int i = 0;
        if (isWinner)
        {
            i = 1;
        }
        else
        {
            i = 0;
        }
        PlayerPrefs.SetInt("isWinner", i);
        PlayerPrefs.SetInt("points", this.pontos);
        PlayerPrefs.SetString("reason", this.endReason);
    }
}

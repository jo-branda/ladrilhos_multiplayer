using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class NetWorkClient : SocketIOComponent
{
    // Start is called before the first frame update
    [SerializeField]
    public List<InfoPeca> tilesFromServer;
    [SerializeField]
    public bool myTurn;
    [SerializeField]
    public int myPoints;
    [SerializeField]
    public int currRound;
    [SerializeField]
    public bool gameOver;
    [SerializeField]
    public bool Iswinner;
    [SerializeField]
    public string endReason;

    public AudioSource source_;
    public AudioClip notif_clip;

    public int sons;

    public override void Start()
    {
        base.Start();
        setupEvents();
    }

    private void setupEvents()
    {
        On("open", (E) =>
         {
             Debug.Log("Connected");

             Emit("enter_pool", JSONObject.Create(""));
         });

        On("turn", (E) =>
        {
            if (E.data["myTurn"].b == true)
            {
                this.myTurn = true;
                Debug.Log("My turn");
                this.source_.PlayOneShot(this.notif_clip);
            }
            else
            {
                Debug.Log("Waiting");
                this.myTurn = false;
            }


        });

        On("board_state", (E) =>
        {
            InfoPeca _peca = new InfoPeca();
            for (int i = 0; i < E.data.Count; i++)
            {                
                _peca.x = (int)E.data[i]["x"].f;
                _peca.y = (int)E.data[i]["y"].f;
                _peca.tileType = E.data[i]["tileType"].ToString().Trim('"'); ;
                tilesFromServer.Add(_peca);
            }
            //this.pecas = JsonHelper.FromJson<InfoPeca>();
            Debug.Log("DATA----> " + _peca.tileType);
        });
        On("points", (E) =>
        {        
            this.myPoints = (int)E.data["points"].f;
        });
        On("round", (E) => {
            Debug.Log("Ronda"+E.data);
            this.currRound = (int)E.data["round"].f;
        });
        On("game_over", (E) => {
            Debug.Log(E.data);
            this.gameOver = true;
            this.Iswinner = E.data["winner"].b;
            this.endReason = E.data["reason"].str;
        });


        void OnEnable()
        {
            this.sons = PlayerPrefs.GetInt("sons");
        }

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void disconnect()
    {
        Close();
    }
}

[Serializable]
    public class InfoPeca
{
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;
    [SerializeField]
    public string tileType;

    public InfoPeca()
    {

    }
    public InfoPeca(int _x, int _y, string _ti)
    {
        this.x = _x;
        this.y = _y;
        this.tileType = _ti;
    }
}
[Serializable]
public class Infoboard
{
    [SerializeField]
    tile[] board;
}



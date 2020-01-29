using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogada : MonoBehaviour
{
    public GameObject CubePrefab;
    public Camera isoCam;
    private List<peca> pecas = new List<peca>(6); // Peças para jogar
    private LinkedList<peca> pecasJogadas = new LinkedList<peca>(); // Peças jogadas
    private Vector2 mouseOver;
    private Vector3 boardOffset = new Vector3(5.0f, 0, 5.0f);
    private Vector3 PecaOffset = new Vector3(0.5f,0, 0.5f);
    private peca pecaAtual;
    private peca pecaSelecionada;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        UpdateMouseOver();
        int _x = (int)mouseOver.x;
        int _y = (int)mouseOver.y;
        ColocaPeca(_x, _y);

        for (int i = 0; i < pecasJogadas.Count; i++)
        {
            int x = pecasJogadas.Last.Value.getPosX;
            Debug.LogError(x);
            
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
                Vector3 position = new Vector3(_x, 0.25f, _y)+ new Vector3(-5.0f, 0, -5.0f) + new Vector3(0.5f, 0, 0.5f);
                GameObject newPeca = Instantiate(CubePrefab,position,Quaternion.identity) as GameObject;
                newPeca.transform.SetParent(transform);
                peca p = newPeca.GetComponent<peca>();
                p.getColor = pecaSelecionada.getColor;
                p.getForm = pecaSelecionada.getForm;
                p.getPosX = _x;
                p.getPosY = _y;
                pecasJogadas.AddLast(p);
                pecaAtual = p;
                //pecas.Remove(p);
            }
        }
    }

    public void ValidMove(peca p)
    {
       //if(pecasJogadas.Count = 0)
       // {
       //     //Set All tiles green
       // }
    }
    public void getPoints()
    {
        // Irá contar os pontos da lista ligada
    }
}

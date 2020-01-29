using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    #region Singleton

    public static hand instance;

    int count = 0;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject selectedTile;
    //public baralho baralho;
    public List<GameObject> pecas = new List<GameObject>();
    void Start()
    {
        selectedTile = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add a new item if enough room
    public void Add(GameObject peca)
    {
        if (pecas.Count >= 6)
        {
            Debug.Log("Not enough room.");
            return;
        }

        Debug.Log("A adicionar peca a hand");
        Debug.Log(peca);
        pecas.Add(peca);

        //if (onItemChangedCallback != null)
        //    onItemChangedCallback.Invoke
    }

    // Remove an item
    public void Remove(GameObject peca)
    {
        pecas.Remove(peca);
        //pecas.Add(null);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void updateTile(GameObject gm)
    {
        if (selectedTile == null)
        {
            Debug.Log("Escolha a peça");
        }
        else
        {
            Debug.Log(gm.name);
            this.selectedTile = gm;
            Debug.Log("Peça" + this.selectedTile.name);
        }
    }

    public string getSelectedCard()
    {
        return this.selectedTile.name;
    }
}

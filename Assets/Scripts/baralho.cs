using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baralho : MonoBehaviour
{
    private List<GameObject> _baralho = new List<GameObject>();
    private List<GameObject> _discardPile = new List<GameObject>();

    // Prefabs
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

    public baralho()
    {
        for (int f = 0; f < 6; f++)
        {
            for (int c = 0; c < 6; c++)
            {
                GameObject tile_prefab = new GameObject("A" + f + c);
                _baralho.Add(tile_prefab);
                _baralho.Add(tile_prefab);
                _baralho.Add(tile_prefab);
            }
        }
        Shuffle();
    }

    public void Shuffle()
    {
        List<GameObject> randomizedList = new List<GameObject>();
        System.Random rnd = new System.Random();
        while (_baralho.Count > 0)
        {
            int index = rnd.Next(0, _baralho.Count); //pick a random item from the master list
            randomizedList.Add(_baralho[index]); //place it at the end of the randomized list
            _baralho.RemoveAt(index);
        }

        for (int i = 0; i < randomizedList.Count; i++)
        {
            _baralho.Add(randomizedList[i]);
        }
    }

    public string TakePeca()
    {
        if (_baralho.Count == 0)
            return null; // baralho vazio

        // take the first card off the deck and add it to the discard pile
        GameObject _peca = _baralho[0];
        //Debug.Log(_baralho[0]);
        _baralho.RemoveAt(0);
        _discardPile.Add(_peca);

        return _peca.name;
    }
}


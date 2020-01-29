using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot_item : MonoBehaviour
{
    public GameObject Item;
    public int index;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPeca(GameObject peca)
    {

        Item = peca;
        tile t = peca.GetComponent<tile>();
        gameObject.GetComponent<Button>().interactable = true;
        gameObject.GetComponent<Image>().sprite = t.Image;
        

    }

    // Clear the slot
    public void ClearSlot()
    {
        Item = null;
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.GetComponent<Button>().interactable = false;
    }

    public int getIndex()
    {
        return index;
    }
}

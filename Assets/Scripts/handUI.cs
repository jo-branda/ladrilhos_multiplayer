using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handUI : MonoBehaviour
{
    public GameObject inventoryUI;  // The entire UI
    public Transform itemsParent;
    // The parent object of all the items
    public Text Txt_Selecionado1;
    public Text Txt_Selecionado2;
    public Text Txt_Selecionado3;
    public Text Txt_Selecionado4;
    public Text Txt_Selecionado5;
    public Text Txt_Selecionado6;

    hand hand;    // Our current inventory

    slot_item[] slots;



    void Start()
    {
        Debug.Log("Entrou na handUI");
        hand = hand.instance;
        hand.onItemChangedCallback += UpdateUI;

        slots = GetComponentsInChildren<slot_item>();

    }

    // Check to see if we should open/close the inventory
    void Update()
    {
        //if (Input.GetButtonDown("Passar a vez"))
        //{
        //    inventoryUI.SetActive(!inventoryUI.activeSelf);
        UpdateUI();
        //}
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < hand.pecas.Count)
            {
                slots[i].AddPeca(hand.pecas[i]);
              
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void getSlotItemByIndex(int index)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].getIndex() == index)
            {
                hand.updateTile(slots[i].Item);
                atualSelecionado(index);
            }
        }
    }

    public void atualSelecionado(int index)
    {
        Txt_Selecionado1.text = "";
        Txt_Selecionado2.text = "";
        Txt_Selecionado3.text = "";
        Txt_Selecionado4.text = "";
        Txt_Selecionado5.text = "";
        Txt_Selecionado6.text = "";

        switch (index)
        {
            case 0:
                Txt_Selecionado1.text = "        ▲ \nSelecionado";
                break;
            case 1:
                Txt_Selecionado2.text = "        ▲ \nSelecionado";
                break;
            case 2:
                Txt_Selecionado3.text = "        ▲ \nSelecionado";
                break;
            case 3:
                Txt_Selecionado4.text = "        ▲ \nSelecionado";
                break;
            case 4:
                Txt_Selecionado5.text = "        ▲ \nSelecionado";
                break;
            case 5:
                Txt_Selecionado6.text = "        ▲ \nSelecionado";
                break;
            default:
                break;
        }
    }


}

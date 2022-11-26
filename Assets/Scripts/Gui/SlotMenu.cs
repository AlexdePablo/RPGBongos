using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.SceneManagement;
using UnityEngine;
using static Mochila;

public class SlotMenu : MonoBehaviour
{
    private Mochila m_mochila;
    public void SetItem(Mochila Back)
    {
        m_mochila = Back;
    }
    public ItemSlot getItem()
    {
        if (transform.childCount != 0)
            foreach (ItemSlot itemslot in m_mochila.slots)
                if (transform.GetChild(0).name == itemslot.item.name)
                    return itemslot;
        return null;
    }
    public void OnClickSlot()
    {
        ItemSlot ItemModif = null;
        if (transform.childCount != 0)
            foreach (ItemSlot itemslot in m_mochila.slots.ToList())
                if (transform.GetChild(0).name == itemslot.item.name)
                {
                    ItemModif = itemslot;
                }
        if (ItemModif != null)
        {
            if (ItemModif.quantitat == 1)
                Destroy(transform.GetChild(0).gameObject);
            m_mochila.Utilizar(ItemModif.item);
        }
    }
}
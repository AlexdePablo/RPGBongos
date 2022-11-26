using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Mochila", menuName = "Scriptables/Mochila")]
public class Mochila : ScriptableObject
{

    [Serializable]

    public class ItemSlot
    {

        [SerializeField] public Item item;
        [SerializeField] public int quantitat;

    }

    public List<ItemSlot> slots;

    public void Utilizar(Item item) {
        Item i = null;
 
        foreach(ItemSlot itemslot in slots.ToList())
        {
            if (itemslot.item == item)
            {
                i = itemslot.item;
                if (itemslot.quantitat > 1)
                    itemslot.quantitat--;
                else
                    slots.Remove(itemslot);
            }
        }
            i?.Usar();
    }


    public void Añadir(Item item) {
        /*ItemSlot slot = new ItemSlot();
        slot.item = item;
        slot.quanitat++;
        slots.Add(slot);*/

        ItemSlot slot = new ItemSlot();

        bool nuevo = true;

        foreach (ItemSlot itemslot in slots)
        {

            if (itemslot.item.nom.Equals(item.nom))
            {
                itemslot.quantitat++;
                nuevo = false;
            }
        }
        if (nuevo)
        {
            slot.item = item;
            slot.quantitat = 1;
            slots.Add(slot);
        }
    }

  
}

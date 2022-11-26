using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Mochila;

public class ForGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    //TODO que el Playe te lo plle directamente, si hay party etc...
    [SerializeField]
    private PlayerScriptable Plyer_Info;
    void Start()
    {
        Create();
    }
    private void Create()
    {
        for (float i = 0; i < GetComponent<RectTransform>().sizeDelta.x; i += GetComponent<GridLayoutGroup>().cellSize.x)
        {
            for (float j = 0; j < GetComponent<RectTransform>().sizeDelta.y; j += GetComponent<GridLayoutGroup>().cellSize.y)
            {
                Object Slot = Instantiate(Menu);
                Slot.GameObject().transform.SetParent(transform);
            }
        }
        Sustituir();
    }
    //TODO mirar que se ordene
    public void Sustituir()
    {
        List<ItemSlot> ItemsConsumibles = new List<ItemSlot>();
        for (int i = 0; i < Plyer_Info.mochila.slots.Count; i++)
        {
            if (Plyer_Info.mochila.slots[i].item is Consumibles)
                ItemsConsumibles.Add(Plyer_Info.mochila.slots[i]);
        }
        int Element = 0;
        for (float i = 0; i < GetComponent<RectTransform>().sizeDelta.x; i += GetComponent<GridLayoutGroup>().cellSize.x)
        {

            for (float j = 0; j < GetComponent<RectTransform>().sizeDelta.y; j += GetComponent<GridLayoutGroup>().cellSize.y)
            {
                if (ItemsConsumibles.Count > Element)
                {
                    if (transform.GetChild(Element).transform.childCount != 0)
                        Destroy(transform.GetChild(Element).transform.GetChild(0).gameObject);
                    transform.GetChild(Element).GetComponent<SlotMenu>().SetItem(Plyer_Info.mochila);
                    GameObject EmptyObject = new GameObject(ItemsConsumibles.ElementAt(Element).item.name);
                    EmptyObject.transform.SetParent(transform.GetChild(Element).transform);
                    EmptyObject.AddComponent<Image>();
                    EmptyObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(ItemsConsumibles.ElementAt(Element).item.name + "_Image");
                    EmptyObject.GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<GridLayoutGroup>().cellSize.x, GetComponent<GridLayoutGroup>().cellSize.y);
                    EmptyObject.transform.position = new Vector2(0, 0);
                }
                Element++;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.Requests;
using UnityEditor.Presets;
using UnityEditor;
using UnityEngine;
using static Mochila;

public class GuiBackPack : MonoBehaviour
{
    [SerializeField]
    private Mochila mochila;
    [SerializeField]
    private GameObject Item;


    private void Start()
    {
        ReloadBackpack();
    }

    private void ReloadBackpack()
    {
        while (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0));
        }
            

        foreach (ItemSlot slot in mochila.slots)
        {
            GameObject button = Instantiate(Item, transform);
            Debug.Log(slot.item);
  
           
        }
    }
}

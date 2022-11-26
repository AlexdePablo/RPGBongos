using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private RecogerObjetoEvent roe;


    private void RaiseEvent() {


        roe.Raise(this.item);
        Destroy(this.gameObject);

    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            RaiseEvent();

        }
    }



}

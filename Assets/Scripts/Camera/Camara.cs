using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3Int((int)player.transform.position.x, (int)player.transform.position.y,-10);
    }
}

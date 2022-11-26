using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armaduras", menuName = "Scriptables/Armadura")]
public class Armaduras : Item
{
    public SeAcabaronLosUsosEvent salue;
    public UsarObjetoEvent uoe;
    public float dfsFisica;
    public float dfsMagica;
    public int usos;


    public override void Usar()
    {
        if (usos > 0) {

            uoe.Raise(this);
         

        }

       else if (usos == 0) {

            salue.Raise();

        
        }
 
    }
}


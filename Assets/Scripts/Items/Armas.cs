using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armas", menuName = "Scriptables/Arma")]
public class Armas : Item
{
    public SeAcabaronLosUsosEvent salue;
    public UsarObjetoEvent uoe;
    public float atkFisico;
    public float atkMagico;
    public int usos;

    public override void Usar()
    {
        if (this.usos > 0) {

            uoe.Raise(this);
        
        }
       else if (usos == 0) {

            salue.Raise();
        

        }

    }

}

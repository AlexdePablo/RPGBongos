using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumibles", menuName = "Scriptables/Consumibles")]
public class Consumibles : Item
{
    public UsarObjetoEvent uoe;
    public float atkFisicoAugmento;
    public float atkMagicoAugmento;
    public float dfsFisicaAugmento;
    public float dfsMagicaAugmento;
    public float vidaRestaurada;
    public float magiaRestaurada;

    public override void Usar()
    {
        uoe.Raise(this);
    }


}

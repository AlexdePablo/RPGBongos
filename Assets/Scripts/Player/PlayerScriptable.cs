using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptables/Player")]
public class PlayerScriptable : ScriptableObject
{
    public float vida;
    public float magia;
    public float atkFisico;
    public float atkMagico;
    public float dfsFisica;
    public float dfsMagica;
    public float xp;
    public Mochila mochila;
    public Armas ArmaActual;
    public Armaduras ArmaduraActual;
    public int movimentMaxim;



}

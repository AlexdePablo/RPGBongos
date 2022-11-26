using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptable", menuName = "Enemy/Enemy")]
public class EnemyScriptable : ScriptableObject
{
    public string nom;
    public float vida;
    public float magia;
    public float xp;
    public float atkFisico;
    public float atkMagico;
    public float dfsFisica;
    public float dfsMagica;

    public void LoadInfo(EnemyScriptable info)
    {
        nom = info.nom;
        vida = info.vida;
        magia = info.magia;
        xp = info.xp;
        atkFisico = info.atkFisico;
        atkMagico = info.atkMagico;
        dfsFisica = info.dfsFisica;
        dfsMagica = info.dfsMagica;
    }
}

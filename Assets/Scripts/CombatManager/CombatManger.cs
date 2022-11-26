using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using Random = UnityEngine.Random;



public class CombatManger : MonoBehaviour
{
    [SerializeField]
    private TurnoEvent tp;
    [SerializeField]
    private TurnoEnemigoEvent te;
    [SerializeField]
    private PlayerScriptable player;
    [SerializeField]
    private EnemyScriptable enemy;
    [SerializeField]
    private bool turno;


    void Start()
    {
        if (Random.Range(0, 2) == 0)
            turno = false;
        else
            turno = true;

        LlamarTurno();
    }

    public void FinalTurno()
    {
        turno = !turno;
        LlamarTurno();
    }

    private void LlamarTurno()
    {
        if (turno)
            TurnoPlayer();
        else
            TurnoEnemigo();
    }

    void TurnoPlayer() {
        tp.Raise();
    }


    void TurnoEnemigo()
    {
        te.Raise();
    }
}

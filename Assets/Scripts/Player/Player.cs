using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private PlayerScriptable Mainplayer;
    


    private float atkFisicoOriginal;
    private float atkMagicoOriginal;
    private float dfsFisicaOriginal;
    private float dfsMagicaOriginal;
    private bool accionAtacar;
    private bool accionUsarItem;

    public float vida;
    public float magia;
    public float atkFisico;
    public float atkMagico;
    public float dfsFisica;
    public float dfsMagica;
   



    void Start()
    {
        loadInfoOriginal();
        loadInfo();
    }

    public void Usar(Item item) {
        Mainplayer.mochila.Utilizar(item);
    }

    public void Añadir(Item item)
    {
        Mainplayer.mochila.Añadir(item);
    }

    public void Equipar(Item item) {
        Consumibles i = null;
        Armas a = null;
        Armaduras ar = null;
        if (item is Consumibles && accionUsarItem)
        {
            i = item as Consumibles;

            this.vida += i.vidaRestaurada;
            this.magia += i.magiaRestaurada;
            this.atkFisico += i.atkFisicoAugmento;
            this.atkMagico += i.atkMagicoAugmento;
            this.dfsFisica += i.dfsFisicaAugmento;
            this.dfsMagica += i.dfsMagicaAugmento;
            accionUsarItem = false;

        }
        else if (item is Armas)
        {
            this.atkFisico = atkFisicoOriginal;
            this.atkMagico = atkMagicoOriginal;
        
            a = item as Armas;

            Mainplayer.ArmaActual = a;

            this.atkFisico = Mainplayer.atkFisico + Mainplayer.ArmaActual.atkFisico;
            this.atkMagico = Mainplayer.atkMagico + Mainplayer.ArmaActual.atkMagico;

        }
        else if (item is Armaduras) {

            this.dfsFisica = dfsFisicaOriginal;
            this.dfsMagica = dfsMagicaOriginal;

            ar = item as Armaduras;

            Mainplayer.ArmaduraActual = ar;

            this.dfsFisica = Mainplayer.dfsFisica + Mainplayer.ArmaduraActual.dfsFisica;
            this.dfsMagica = Mainplayer.dfsMagica + Mainplayer.ArmaduraActual.dfsMagica;

        }

    }

    public void loadInfoOriginal() {

        this.atkFisicoOriginal = Mainplayer.atkFisico;
        this.atkMagicoOriginal = Mainplayer.atkMagico;
        this.dfsFisicaOriginal = Mainplayer.dfsFisica;
        this.dfsMagicaOriginal = Mainplayer.dfsMagica;
    
    }

    public void loadInfo()
    {

        this.vida = Mainplayer.vida;
        this.magia = Mainplayer.magia;
        this.atkFisico = Mainplayer.atkFisico;
        this.atkMagico = Mainplayer.atkMagico;
        this.dfsFisica= Mainplayer.dfsFisica;
        this.dfsMagica = Mainplayer.dfsMagica;



    }

    public void atkmelee()
    {
        if (accionAtacar) {
            enemy.recibirDañoMelee();
            accionAtacar = false;
        }

    
    }
    public void atkmagia()
    {
        if (accionAtacar)
        {
            enemy.recibirDañoMagico();
            accionAtacar = false;
        }
      

    }
    public void RecibirDañoMelee() {
        this.vida += (this.dfsFisica - enemy.atkFisico);
        print("El enemigo me ataca");
    }

    public void RecbirDañoMagico() {

        this.vida += (this.dfsMagica - enemy.atkMagico);
        print("El enemigo me ataca....Magicamente");
    }


    public void JugarTurno() {
        accionUsarItem = true;
        accionAtacar = true;
    }
   
}

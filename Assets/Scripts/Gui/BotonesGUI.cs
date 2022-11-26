using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonesGUI : MonoBehaviour
{ 
    [SerializeField]
    private GameObject opcionesCombate;
    [SerializeField]
    private GameObject Backpack;
    [SerializeField]
    private GameObject menuAtaques;
    [SerializeField]
    AtacarEnemigoEvent amelee;
    [SerializeField]
    AtacarEnemigoEvent amagia;
    [SerializeField]
    TurnoEvent turno;





    public void atacarMelee() {

        amelee.Raise();
    
    
    }


    public void atacarMagia()
    {

        amagia.Raise();


    }
    public void abrirBackpack()
    {
        opcionesCombate.SetActive(false);
        Backpack.SetActive(true);
    }
    public void tornaBackPack()
    {
        opcionesCombate.SetActive(true);
        Backpack.SetActive(false);
    }
    public void loSuponia()
    {
        SceneManager.LoadScene("PathfinfingHexagonal");
    }
    public void abrirTiposDeAtaques()
    {
        opcionesCombate.SetActive(false);
        menuAtaques.SetActive(true);

    }
    public void tornaTiposAtaques()
    {
        opcionesCombate.SetActive(true);
        menuAtaques.SetActive(false);
    }

    public void ChangeTurn() {

        turno.Raise();

        opcionesCombate.transform.GetChild(0).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(1).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(2).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(3).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(4).GetComponent<Button>().interactable = false;

    }

    public void PlayerTurn() {

        opcionesCombate.transform.GetChild(0).GetComponent<Button>().interactable = true;
        opcionesCombate.transform.GetChild(1).GetComponent<Button>().interactable = true;
        opcionesCombate.transform.GetChild(2).GetComponent<Button>().interactable = true;
        opcionesCombate.transform.GetChild(3).GetComponent<Button>().interactable = true;
        opcionesCombate.transform.GetChild(4).GetComponent<Button>().interactable = true;


    }

    public void SetFalse()
    {

        opcionesCombate.transform.GetChild(0).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(1).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(2).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(3).GetComponent<Button>().interactable = false;
        opcionesCombate.transform.GetChild(4).GetComponent<Button>().interactable = false;


    }


}

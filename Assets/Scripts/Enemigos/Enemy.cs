using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyScriptable es;
    [SerializeField]
    private Player player;
    [SerializeField]
    private TurnoEnemigoEvent finalTurno;

    public float atkFisico;
    public float atkMagico;
    public float dfsFisica;
    public float dfsMagica;
    public float vida;
    private float xp;
    

    private void Start()
    {
        loadInfoEnemy();
    }

    private void MeMuero() {

        if (this.vida <= 0)
        {

            Destroy(this.gameObject);
            SceneManager.LoadScene("PathfinfingHexagonal");

        }

    }


    public void recibirDañoMelee() {

        this.vida += (this.dfsFisica - player.atkFisico);
        MeMuero();
 

    }

    public void recibirDañoMagico()
    {

        this.vida += (this.dfsMagica - player.atkMagico) ;
        MeMuero();
       

    }

    public void curar() {
        float randomHeal = Random.Range(0, 10); 
        this.vida += randomHeal;
        print("El enemigo se cura: " + randomHeal);
    
    }

    public void loadInfoEnemy() {

        this.atkFisico = es.atkFisico;
        this.atkMagico = es.atkMagico;
        this.dfsFisica = es.dfsFisica;
        this.dfsMagica = es.dfsMagica;  
    
    
    }
    

    public void TurnoEnemigo()
    {
        StartCoroutine(TurnoEnemigoCorrutina());
    }

    IEnumerator TurnoEnemigoCorrutina()
    {


        print("El enemigo te mira mal");
        yield return new WaitForSeconds(2);
        if (Random.Range(1, 4) == 1)
        {

            curar();

        }
        else if (Random.Range(1, 4) == 2)
        {

            player.RecibirDañoMelee();
        }
        else {

            player.RecbirDañoMagico();
        }
        yield return new WaitForSeconds(1);
        print("El enemigo finaliza su turno");
        finalTurno.Raise();

    }
}

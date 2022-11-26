using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class EnemigoPath : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    Tilemap m_Tilemap;
    [SerializeField]
    private int m_maximCaselles;
    [SerializeField]
    private float m_velocityMovement;
    [SerializeField]
    EnemyScriptable enemy;
    [SerializeField]
    EnemyScriptable combate;
   
    PathfindingPocho m_Pathfinding;
    Vector3Int m_Origin;
    Vector3Int m_Destiny;
    List<Vector3Int> m_Cells;
    [SerializeField]
    GameObject m_rigidBody2D;

    private void Awake()
    {
        //m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_Pathfinding = GetComponent<PathfindingPocho>();
        m_Cells = new List<Vector3Int>();
    }

  void Update()
    {
      
    }
    public IEnumerator PlayerMoveEvent(List<Vector3Int> m_Cells)
    {
        foreach (Vector3Int cell in m_Cells)
        {
            Vector3 PlayerPosition = transform.position;
            Vector3 destination = m_Tilemap.GetCellCenterWorld(cell);
            Vector2 VelocityToCell = new Vector2((destination.x - PlayerPosition.x), (destination.y - PlayerPosition.y)).normalized * m_velocityMovement;
            GetComponent<Rigidbody2D>().velocity = VelocityToCell;
            while (Vector3.Distance(transform.position, destination) >= m_velocityMovement * Time.fixedDeltaTime)
                yield return new WaitForFixedUpdate();
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        m_Origin = m_Tilemap.WorldToCell(transform.position);
        m_Destiny = m_Tilemap.WorldToCell(m_rigidBody2D.transform.position);
        if (m_Origin == m_Destiny) {

            combate.vida = enemy.vida;
            combate.xp = enemy.xp;
            combate.atkFisico = enemy.atkFisico;
            combate.atkMagico = enemy.atkMagico;
            combate.dfsFisica = enemy.dfsFisica;
            combate.dfsMagica = enemy.dfsMagica;

            SceneManager.LoadScene("CombateDefinitivo");

        }
          
    }
    public void FindPathEnemy(Vector3 posCharacter)
    {
        m_Origin = m_Tilemap.WorldToCell(transform.position);
        m_Origin.z = 0;
       
        m_Destiny = m_Tilemap.WorldToCell(posCharacter);
        m_Destiny.z = 0;
      
        if (m_Pathfinding.IsWalkableTile(m_Origin) && m_Pathfinding.IsWalkableTile(m_Destiny))
        {
           
            //cerquem el nou camí en coordenades de casella
            m_Cells.Clear();
            m_Pathfinding.FindPath(m_Origin, m_Destiny, out m_Cells);
          
            if (m_Cells.Count <= m_maximCaselles)
            {
            
                StartCoroutine(PlayerMoveEvent(m_Cells));
            }
            else
            {
              
            }
           
        }
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PathfindingPocho))]
public class DemoPathfindingPocho : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    Tilemap m_Tilemap;
    [SerializeField]
    Color m_PathColor;
    [SerializeField]
    EnemigoPath enemyPath;
    Color m_colorAntic;
    [SerializeField]
    Color m_PathColorHover;
    [SerializeField]
    private int m_maximCaselles;
    private bool m_activo;
    [SerializeField]
    private float m_velocityMovement;
    Rigidbody2D m_rigidBody2D;
    PathfindingPocho m_Pathfinding;
    Vector3Int m_Origin;
    Vector3Int m_Destiny;
    List<Vector3Int> m_Cells;
    private Vector3Int previousMousePos = new Vector3Int();
    [SerializeField]
    EnemigoPath enemy;
    [SerializeField]
    GameEventVector3 m_ChangeTurn;
   

    private void Awake()
    {

        m_activo = false;
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_Pathfinding = GetComponent<PathfindingPocho>();
        m_Cells = new List<Vector3Int>();
       
    }

   
    void Update()
    {

        Vector3Int mousePos = GetMousePosition();
        GetTileColor(mousePos);
        if (!mousePos.Equals(previousMousePos))
        {
            if (m_colorAntic == m_PathColor)
            {
                ChangeTileColor(m_PathColorHover, mousePos);
                ChangeTileColor(m_colorAntic, previousMousePos);
                previousMousePos = mousePos;
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posicioPersonatge = transform.position;
            Vector3Int destination = m_Tilemap.WorldToCell(posicioPersonatge);
            destination.z = 0;
            m_Origin = m_Tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            m_Origin.z = 0;
            if (m_Origin == destination)
            {
                MostrarCasillasAndables(destination, m_maximCaselles);
                m_activo = true;
            }
            else
            {
                DevolverTileColor();
                print("no");
                m_activo = false;
            }
          
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (m_activo == true)
            {
                DevolverTileColor();
                m_activo = false;

                m_Destiny = m_Tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                m_Destiny.z = 0;
                print(m_Destiny);
                if (m_Pathfinding.IsWalkableTile(m_Origin) && m_Pathfinding.IsWalkableTile(m_Destiny))
                {
                    print("SON WALKABLES");
                    //cerquem el nou camí en coordenades de casella
                    m_Cells.Clear();
                    m_Pathfinding.FindPath(m_Origin, m_Destiny, out m_Cells);
                    if (m_Cells.Count <= m_maximCaselles)
                    {
                        if (m_Destiny != m_Origin)
                        {
                        
                            StartCoroutine(PlayerMoveEvent(m_Cells));
                        }
                       
                    }
                    else
                    {
                        DevolverTileColor();
                        print("Vols anar massa lluny");
                    }
                }
            }

        }

    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        return grid.WorldToCell(mouseWorldPos);
    }


    public void MostrarCasillasAndables(Vector3Int pos, int move)
    {
        List<Vector3Int> listaVisitados = new List<Vector3Int>();
        recursivo(pos, move, listaVisitados);
    }

    public void recursivo(Vector3Int pos, int move, List<Vector3Int> visitados)
    {
        List<Vector3Int> m_Caselles = new List<Vector3Int>();
        List<Vector3Int> listaVecinos = m_Pathfinding.cogerVecinas(pos);
        foreach (Vector3Int vecino in listaVecinos)
        {
            m_Caselles.Clear();
            m_Pathfinding.FindPath(m_Origin, vecino, out m_Caselles);
            if (!visitados.Contains(vecino) && m_Pathfinding.IsWalkableTile(vecino) && m_Caselles.Count <= m_maximCaselles)
            {
                ChangeTileColor(m_PathColor, vecino);
                visitados.Add(pos);
                recursivo(vecino, move - 1, visitados);
            }
        }
    }
    /*
        private float DistanciaHexagonal(Vector3Int a, Vector3Int b)
        {
            Vector3 cuboA = CoordenadaACubo(a);
            Vector3 cuboB = CoordenadaACubo(b);
            return DistanciaCubo(p1, p2);
        }*/

    private Vector3 CoordenadaACubo(Vector3Int coord)
    {
        float x = coord.y - (coord.x - coord.x % 2) / 2;
        float z = coord.x;
        float y = -x - z;

        return new Vector3(x, y, z);
    }
    /* 
        private float DistanciaCubo(Vector3 a, Vector3 b)
        {
            float a = Mathf.Abs(p1(1, 1) - p2(1, 1));
            float b = abs(p1(1, 2) - p2(1, 2));
            float c = abs(p1(1, 3) - p2(1, 3));
            f = max([a, b, c]);^
        }

    function f = offset_distance(x1,y1,x2,y2)
        ac = offset_to_cube(x1,y1);
        bc = offset_to_cube(x2,y2);
        f = cube_distance(ac, bc);
    end

    function f = offset_to_cube(row,col)
        %x = col - (row - (row&1)) / 2;
        x = col - (row - mod(row,2)) / 2;
        z = row;
        y = -x-z;
        f = [x,z,y];
    end

    function f= cube_distance(p1,p2)
        a = abs( p1(1,1) - p2(1,1));
        b = abs( p1(1,2) - p2(1,2));
        c = abs( p1(1,3) - p2(1,3));
        f =  max([a,b,c]);
    end
    */

    private void DevolverTileColor()
    {
        Vector3 posicioPersonatge = transform.position;
        Vector3Int destination = m_Tilemap.WorldToCell(posicioPersonatge);
        for (int i = -m_maximCaselles; i < m_maximCaselles; i++)
        {
            for (int j = -m_maximCaselles; j < m_maximCaselles; j++)
            {
                Vector3Int tile = new Vector3Int(destination.x + i, destination.y + j, 0);
                ChangeTileColor(Color.white, tile);
            }
        }
    }
    private void ChangeTileColor(Color color, Vector3Int vector)
    {
        m_Tilemap.SetTileFlags(vector, TileFlags.None);
        m_Tilemap.SetColor(vector, color);
    }


    private void GetTileColor(Vector3Int vector)
    {
        m_Tilemap.SetTileFlags(vector, TileFlags.None);
        m_colorAntic = m_Tilemap.GetColor(vector);
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
        m_ChangeTurn.Raise(transform.position);
        //enemy.FindPathEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("aaaaaaaaaaaaaaaaaaaaaaaaaa");
            SceneManager.LoadScene("CombateDefinitivo");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("dfgpolasmjkdasnvka");
    }
}

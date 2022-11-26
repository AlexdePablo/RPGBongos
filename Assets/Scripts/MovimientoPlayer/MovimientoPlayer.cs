using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovimientoPlayer : MonoBehaviour
{
  
    [SerializeField]
    private Tilemap m_Tilemap;
    [SerializeField]
    private Color m_PathColor;
    Pathfinding m_Pathfinding;
    public int m_DistanceForTurn;
    Vector3 posicioCharacter;
    Vector3 cliked;
    List<Vector3> m_Cells;
    [SerializeField] private float m_Speed = 3;
    Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Pathfinding = GetComponent<Pathfinding>();
        m_DistanceForTurn = 5;
        m_Cells = new List<Vector3>();
    }


    //Para usar findpathworldSpace usar vector3 los vectores, para findPath usar vector3Int
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posicioCharacter = Vector3Int.FloorToInt(transform.position);
            cliked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DemoPathfinding.Instance.FindPathWorldSpace(cliked, posicioCharacter, out m_Cells);
            StartCoroutine(PlayerMoveEvent());
        }
    }


    public IEnumerator PlayerMoveEvent()
    {
        foreach (Vector3 cell in m_Cells)
        {
            Vector3 direction = (cell - transform.position).normalized;
            m_Rigidbody.velocity = direction * m_Speed;
            while(Vector3.Distance(transform.position, cell) >= m_Speed*Time.fixedDeltaTime)
                yield return new WaitForFixedUpdate();
        }
        m_Rigidbody.velocity = Vector3.zero;
    }

    private void ChangeTileColorSA(Vector3Int pos, int move)
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (j == 0 && i != 0 || i == 0 && j != 0)
                {
                    Vector3Int vec = new Vector3Int(pos.x + i, pos.y + j, 0);
                    if (m_Pathfinding.IsWalkableTile(vec) && move > 1)
                    {
                        ChangeTileColorSA(vec, move - 1);
                        ChangeTileColor(Color.white, vec);
                    }
                }
            }
        }
    }
    private void ChangeTileColor(Color color, Vector3Int vector)
    {
        m_Tilemap.SetTileFlags(vector, TileFlags.None);
        m_Tilemap.SetColor(vector, color);
    }
}

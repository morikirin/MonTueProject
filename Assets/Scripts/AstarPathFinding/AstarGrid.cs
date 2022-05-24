using UnityEngine;
using System.Collections;

public class AstarGrid : MonoBehaviour
{
    private Node[,] grid;
    public LayerMask unwalkableMask;
    /// <summary>
    /// 總範圍大小
    /// </summary>
    public Vector2 gridWorldSize;
    /// <summary>
    /// 節點大小(半徑)
    /// </summary>
    public float nodeRadius;
    /// <summary>
    /// 節點大小(直徑)
    /// </summary>
    private float nodeDiameter;
    /// <summary>
    /// Grid格數化 矩陣的 行(X) 與 列(Y)
    /// </summary>
    private int gridSizeX, gridSizeY;
    public Transform player;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreatGrid();
    }
    private void CreatGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * gridWorldSize / 2 - Vector2.up * gridWorldSize / 2;


        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics2D.OverlapBox(worldPoint, new Vector2(nodeRadius, nodeRadius), unwalkableMask));
                grid[x, y] = new Node(walkable, worldPoint);
            }
        }
    }

    public Node GetNodeFromWorldPoint(Vector2 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
        Debug.Log("x= " + percentX + ", y= " + percentY);
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector2.one * (nodeDiameter - 0.1f));
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridSystem : MonoBehaviour
{
    public List<GameObject> spawnedTiles = new();
    public GameObject[,] grid;

    public List<Factory> factories = new();
    public List<WareHouse> wareHouses = new();
    public List<House> houses = new();

    public GameObject factory;
    public GameObject house;
    public GameObject warehouse;
    [Space]
    public GameObject selected;
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;

    private readonly int gridX = 50;
    private readonly int gridY = 50;

    private void Awake()
    {
        grid = new GameObject[gridX, gridY];

        FillGrid();
    }

    public void FillGrid()
    {

        GameObject[,] grid = new GameObject[50, 50];
        int current = 0;
        foreach(Transform t in transform)
        {
            GridTile tile = t.GetComponent<GridTile>();
            tile.parent = this;
            int y = current / gridY;
            int x = current - y * gridX;
            tile.positionInGrid = new Vector2(x, y);
            grid[x, y] = t.gameObject;
            current++;
        }
    }

    public GridTile Get(int x , int y)
    {
        if (x >= gridX || x < 0 || y >= gridY || y < 0) return null;
        return grid[x, y].GetComponent<GridTile>();
    }
}

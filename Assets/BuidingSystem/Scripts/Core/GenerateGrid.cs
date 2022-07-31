using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public int gridDimensions;
    public float gridSpacing;

    public GameObject gridPrefab;

    private Vector3 lastPos;
    private Vector3 originPos;
    public List<GameObject> spawnedTiles = new List<GameObject>();
    private void Awake()
    {
        generateGrid();
    }
    public void generateGrid()
    {
        lastPos = (Vector2)new Vector3(0, 0, 0);
        originPos = lastPos;
        for (int i = 0; i < gridDimensions; i++)
        {
            for (int ix = 0; ix < gridDimensions; ix++)
            {
                GameObject GridItem = Instantiate(gridPrefab, lastPos + new Vector3(gridSpacing, 0, 0), Quaternion.identity);
                lastPos = GridItem.transform.position;
                spawnedTiles.Add(GridItem);
            }
            lastPos = originPos += new Vector3(0, gridSpacing, 0);
        }
        transform.position = new Vector3(gridDimensions / 2 - gridSpacing, gridDimensions / 2 - gridSpacing, 0);
        for (int i = 0; i < spawnedTiles.Count; i++)
        {
            spawnedTiles[i].transform.parent = transform;
            GridTile tile = spawnedTiles[i].GetComponent<GridTile>();
        }
    }
}

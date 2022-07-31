using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridTile : MonoBehaviour
{
    public enum Type
    {
        Factory,
        Empty,
        House,
        WareHouse
    }
    public enum Direction
    {
        up,
        down,
        left,
        right
    }
    public Type type;
    [HideInInspector]
    public GridSystem parent;
    public Vector2 positionInGrid;

    public bool IsEmpty()
    {
        return type == Type.Empty;
    }

    public GridTile GetNeighbour(Direction dir)
    {
        int x = (int)positionInGrid.x;
        int y = (int)positionInGrid.y;
        switch(dir)
        {
            case Direction.up:
                return parent.Get(x, y + 1);
            case Direction.down:
                return parent.Get(x, y - 1);
            case Direction.left:
                return parent.Get(x - 1, y);
            case Direction.right:
                return parent.Get(x + 1, y);
        }
        return null;
    }
}

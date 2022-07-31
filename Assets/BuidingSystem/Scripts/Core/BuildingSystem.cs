using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class BuildingSystem : MonoBehaviour
{
    public enum TileToPlace
    {
        Factory,
        House,
        WareHouse,
        NotBuilding
    }
    public TileToPlace tile;
    public GridSystem Grid;

    private GameObject previewObject;
    private void Awake()
    {
        Grid.onMouseEnter.AddListener(StartPreview);
        Grid.onMouseExit.AddListener(EndPreview);
    }

    public void StartPreview()
    {
        Grid.selected.GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void EndPreview()
    {
        Grid.selected.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnMousePush(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            Grid.selected.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}

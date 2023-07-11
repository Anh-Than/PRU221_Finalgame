using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Assets.Scripts.RealGameScripts.GameSceneEnum;

public class RemoveTower : MonoBehaviour
{
    public GameObject shovel;
    public Vector2 defaultPosition;
    public MouseState mouseState = MouseState.None;

    public Vector2 mousePos = Vector3.zero;
    public Vector3Int cellPosDefault;
    public Vector3 cellPosCenter;

    public Tilemap tilemap;

    public GameObject highlight;
    public GameObject highlightPrefab;
    private void Start()
    {
        defaultPosition = shovel.transform.position;
    }
    void Update()
    {
        GetAllUpdatePositions();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseState == MouseState.Shovel)
        {
            shovel.transform.position = mousePos;
        }

        if (highlight != null)
        {
            highlight.transform.position = cellPosCenter;
        }
    }

    public void OnMouseDown()
    {
        if (mouseState != MouseState.Shovel)
        {
            mouseState = MouseState.Shovel;
            highlight = Instantiate(highlightPrefab, cellPosCenter, Quaternion.identity);
            highlight.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            highlight.GetComponent<SpriteRenderer>().sortingOrder = -9;
        }
        else
        {
            mouseState = MouseState.None;
            Remove();
            Destroy(highlight);
            shovel.transform.position = defaultPosition;
        }

    }

    public void Remove()
    {
        Collider2D[] tower = Physics2D.OverlapCircleAll(mousePos, 0.03f);
        foreach (Collider2D c in tower)
        {
            if (c.gameObject.CompareTag("Tower"))
            {
                Destroy(c.gameObject);
                FindObjectOfType<PlaceTower>().RevertCellState(cellPosDefault);
                Debug.Log("Remove");
            }
        }
    }
    private void GetAllUpdatePositions()
    {
        //get the world space position of the mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //get the position of the cell in the tilemap (bottom left corner)
        cellPosDefault = tilemap.WorldToCell(mousePos);
        //get the center position of the cell
        cellPosCenter = tilemap.GetCellCenterWorld(cellPosDefault);
    }

}

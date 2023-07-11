using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static Assets.Scripts.RealGameScripts.GameSceneEnum;
using static UnityEditor.PlayerSettings;

public class PlaceTower : MonoBehaviour
{
    //id of tower to spawn
    public int spawnID = -1;
    //list of towers (prefabs) that will instatiate
    public List<GameObject> towerPrefabs;
    //list of towers (UI)
    public List<Image> towerUIs;
    //Spawnable Tilemap
    public Tilemap spawnTilemap;

    //State of mouse
    public MouseState mouseState = MouseState.None;
    //State of tower preview
    public bool isPreview = false;

    //Mouse position
    public Vector2 mousePos = Vector3.zero;
    public Vector3Int cellPosDefault;
    public Vector3 cellPosCenter;

    //Preview tower
    public GameObject previewTower;
    public GameObject highlight;
    public GameObject highlightPrefab;

    private void Update()
    {
        //get positions that are always updated
        GetAllUpdatePositions();

        if (CanSpawn())
        {
            DetectSpawnPoint();
        }

        if (mouseState == MouseState.TowerSelected)
        {
            //Spawn a preview of the tower at the mousePosition           
            if (!isPreview)
            {
                previewTower = SpawnPreviewTower(mousePos);
                highlight = Instantiate(highlightPrefab, cellPosCenter, Quaternion.identity);
            }
            if (isPreview)
            {
                //Preview tower follow mouse
                previewTower.transform.position = mousePos;

                if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
                {
                    highlight.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                    highlight.GetComponent<SpriteRenderer>().sortingOrder = -9;
                    highlight.transform.position = cellPosCenter;
                }
                else
                {
                    highlight.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.6f);
                    highlight.GetComponent<SpriteRenderer>().sortingOrder = -9;
                    highlight.transform.position = cellPosCenter;
                }
            }
        }
    }

    private void GetAllUpdatePositions()
    {
        //get the world space position of the mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //get the position of the cell in the tilemap (bottom left corner)
        cellPosDefault = spawnTilemap.WorldToCell(mousePos);
        //get the center position of the cell
        cellPosCenter = spawnTilemap.GetCellCenterWorld(cellPosDefault);
    }
    private GameObject SpawnPreviewTower(Vector3 pos)
    {
        isPreview = true;
        return Instantiate(towerPrefabs[spawnID], pos, Quaternion.identity);
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
        {
            return false;
        }
        return true;
    }

    void DetectSpawnPoint()
    {
        //Detect when mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //check if the cell is spawnable (collider)
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                Spawn(cellPosCenter, cellPosDefault);
                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
            }
        }
    }

    private void Spawn(Vector3 position, Vector3Int cellPosition)
    {
        Instantiate(towerPrefabs[spawnID], position, Quaternion.identity);
        //Deselect tower
        DeselectTower();
    }

    public void SelectTower(int id)
    {
        DeselectTower();
        //Set spawnId
        spawnID = id;
        //Set current state of mouse
        mouseState = MouseState.TowerSelected;
    }

    public void DeselectTower()
    {
        if (spawnID != -1)
        {
            //Disable card outline if previously selected
        }
        //Reset spawnID
        spawnID = -1;
        //Disable tower preview
        Destroy(previewTower);
        Destroy(highlight);
        isPreview = false;
        //Reset state of mouse
        mouseState = MouseState.None;
    }

    public void RevertCellState(Vector3Int pos)
    {
        spawnTilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
    }
}

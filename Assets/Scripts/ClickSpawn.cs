using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    Tilemap spawnTilemap;

    Vector2 pos;
    Vector3Int cellPosDefault;
    Vector3 cellPosCenter;

    GameObject preview;
    GameObject previewGhost;
    // Start is called before the first frame update
    void Start()
    {
        preview = Instantiate(enemy);
        previewGhost = Instantiate(enemy);
        previewGhost.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
        previewGhost.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cellPosDefault = spawnTilemap.WorldToCell(pos);
        cellPosCenter = spawnTilemap.GetCellCenterWorld(cellPosDefault);

        HighlightVerticalAndHorizontalCell();

        if (preview != null)
        {
            preview.transform.position = pos;
        }
        if (previewGhost != null)
        {
            previewGhost.transform.position = cellPosCenter;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
            Destroy(preview);
            Destroy(previewGhost);
        }


    }

    private void Spawn()
    {
        if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
        {
            Instantiate(enemy, cellPosCenter, Quaternion.identity);
        }
    }

    private void HighlightVerticalAndHorizontalCell()
    {
        spawnTilemap.SetTileFlags(cellPosDefault, TileFlags.None);
        spawnTilemap.SetColor(cellPosDefault, Color.white);
    }
}

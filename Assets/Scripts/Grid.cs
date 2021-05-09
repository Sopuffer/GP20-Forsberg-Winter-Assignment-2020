using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    public int rows = 10;
    [SerializeField]
    public int cols = 10;
    [SerializeField]
    float tileSize = 1;
    public GameObject tile;

    TileManager tileManager;
    Tile _tile;
    private void Awake()
    {
        tileManager = FindObjectOfType<TileManager>();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        GameObject go = Instantiate(tile);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = Instantiate(go, transform);
                _tile = tile.GetComponent<Tile>();
                tileManager.tiles.Add(tile);
                tileManager.tileScripts.Add(_tile);
                float posX = col * tileSize;
                float posY = row * tileSize;
                tile.transform.localPosition = new Vector2(posX, posY);
            }
        }
        Destroy(go);
        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2((-gridW / 2 + tileSize / 2), (-gridH / 2 - tileSize / 2));
            
    }
}

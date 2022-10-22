using UnityEngine;
using UnityEngine.Tilemaps;

public class Noise : MonoBehaviour
{
    [Header("Grid Settings")]
    public int width = 256;
    public int height = 256;
    public int smoothAmount = 1;
    int[] perlinHeightList;

    [Header("Hill Settings")]
    [Range(0, 100)]
    [SerializeField] int randomFillPercentage;

    [Header("Tile Assets")]
    [SerializeField] TileBase groundTile;
    [SerializeField] TileBase hillTile;
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] Tilemap hillTilemap;

    public float seed;

    int[,] map;

    private void Start()
    {
        perlinHeightList = new int[width];
        Generation();
    }
    public int[,] GenerateArray(int width, int height, bool empty)
    {
        int[,] map = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = (empty) ? 0 : 1;
            }
        }
        return map;
    }
    public int[,] TerrainGeneration(int[,] vs)
    {
        System.Random value = new System.Random(seed.GetHashCode());
        int perlinHeight;
        for (int x = 0; x < width; x++)
        {
            perlinHeight = Mathf.RoundToInt(Mathf.PerlinNoise(x, seed) * height / 2);
            perlinHeight += height / 2;
            perlinHeightList[x] = perlinHeight;
            for (int y = 0; y < perlinHeight; y++)
            {
                map[x, y] = (value.Next(1, 100) < randomFillPercentage) ? 1 : 2;
            }
        }
        return map;
    }

    void Smoothing( int smoothAmount)
    {
        for (int i = 0; i < smoothAmount; i++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < perlinHeightList[x]; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == perlinHeightList[x] - 1)
                    {
                        map[x, y] = 1;
                    }
                    else 
                    {
                        int surroundingGroundCount = GetSurroundingGroundCount(x, y);

                        if (surroundingGroundCount > 4)
                        {
                            map[x, y] = 1;
                        }
                        else if (surroundingGroundCount < 4)
                        {
                            map[x, y] = 2;
                        }
                    }
                }
            }
        }
        
    }
    public void RenderMap(int[,] map, Tilemap groundTilemap, Tilemap hillTilemap, TileBase groundTilebase, TileBase hillTilebase)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                    groundTilemap.SetTile(new Vector3Int(x, y, 0), groundTilebase);
                }
                else if (map[x, y] == 2)
                {
                    hillTilemap.SetTile(new Vector3Int(x, y, 0), hillTilebase);
                }
            }
        }
    }

    void Generation()
    {
        seed = Random.Range(1, 100);
        clearMap();
        map = GenerateArray(width, height, true);
        map = TerrainGeneration(map);
        Smoothing(smoothAmount);
        RenderMap(map, groundTilemap, hillTilemap, groundTile, hillTile);
    }

    void clearMap()
    {
        groundTilemap.ClearAllTiles();
        hillTilemap.ClearAllTiles();
    }

    int GetSurroundingGroundCount(int gridX, int gridY)
    {
        int groundCount = 0;

        for (int neighX = gridX - 1; neighX <= gridX + 1; neighX++)
        {
            for (int neighY = gridY - 1; neighY <= gridY + 1; neighY++)
            {
                if (neighX >= 0 && neighX < width && neighY >= 0 && neighY < height)
                {
                    if (neighX != gridX || neighY != gridY)
                    {
                        if (map[neighX, neighY] == 1)
                        {
                            groundCount++;
                        }
                    }
                }
            }
        }
        return groundCount;
    }
}

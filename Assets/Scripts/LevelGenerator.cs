using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TileMaps;

public class LevelGenerator : MonoBehaviour
{   
    private TileBase[] tiles;
    public TileMap tileMap;
    // Start is called before the first frame update
    void Start()
    {
        int[,] levelMap = {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };

        int[,] rotationData = new int[levelMap.GetLength(0), levelMap.GetLength(1)];

        tiles = Resources.LoadAll<TileBase>("Tiles/TestPalette");

        for (x = 0; x < levelMap.GetLength(0); x++) {
            for (y = 0; y < levelMap.GetLength(1); y++) {
                switch (levelMap[x, y]) {
                    case 0:
                        tileMap.SetTile(new Vector3Int(x, y, 0), tiles[22]);
                        rotationData[x, y] = 0;
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        tileMap.SetTile(new Vector3Int(x, y, 0), tiles[23]);
                        rotationData[x, y] = 0;
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

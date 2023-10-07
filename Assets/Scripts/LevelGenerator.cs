using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{   
    public TileBase[] tiles;
    public Tilemap tileMap;
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

        // tiles = Resources.LoadAll<TileBase>("Tiles/TestPallete");
        foreach (TileBase tile in tiles) {
            Debug.Log(tile);
        }

        for (int y = 0; y < levelMap.GetLength(0); y++) {
            for (int x = 0; x < levelMap.GetLength(1); x++) {
                Matrix4x4 matrix;
                var value = levelMap[y, x];
                tileMap.SetTile(new Vector3Int(x, -y, 0), tiles[value]);
                switch (value) {
                    case 0:
                        rotationData[y, x] = 0;
                        break;
                    case 1:
                        rotationData[y, x] = 0;
                        break;
                    case 2:
                        rotationData[y, x] = 0;
                        break;
                    case 3:
                        rotationData[y, x] = 0;
                        break;
                    case 4:
                        try {
                            if (((levelMap[y, x-1] == 3) || (levelMap[y, x-1] == 4 && rotationData[y, x-1] == 1)) && ((levelMap[y, x+1] == 3) || (levelMap[y, x+1] == 4))) {
                                rotationData[y, x] = 1;
                            } else {
                                matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
                                tileMap.SetTransformMatrix(new Vector3Int(x, -y, 0),matrix);
                                rotationData[y, x] = 2;
                            }
                        } catch (System.Exception err) {
                            Debug.Log("err");
                            matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
                            tileMap.SetTransformMatrix(new Vector3Int(x, -y, 0),matrix);
                        }
                        break;
                    case 5:
                        rotationData[y, x] = 0;
                        break;
                    case 6:
                        rotationData[y, x] = 0;

                        break;
                    case 7:
                        rotationData[y, x] = 0;
                        break;
                }
                Debug.Log("V: " + value + ", R: " + rotationData[y, x]);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

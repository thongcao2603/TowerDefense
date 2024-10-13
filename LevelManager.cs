using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] private GameObject[] tilePrefabs;


    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private Transform map;

    [SerializeField] private GameObject bluePortalPrefab;
    [SerializeField] private GameObject redPortalPrefab;

    private Point blueSpawn, redSpawn;


    //Tiles với key la Point(x,y) ,value la TileScript
    public Dictionary<Point, TileScript> Tiles { get; set; }

    // trả về size của 1 Tile
    public float TileSize
    {
        get
        {
            return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }
    }
    void Start()
    {
        CreateLevel();
    }


    // create map với data đọc từ Resources
    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();
        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        //điểm bắt đầu là góc Top left
        Vector3 startPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(), x, y, startPos);
            }
        }
        //ví trí top left của ô bottom right
        maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        //limit di chuyển camera
        cameraMovement.SetLimits(new Vector3(maxTile.x + TileSize, maxTile.y - TileSize));
        SpawnPortals();
    }
    //đặt tile theo tileType(mảng tilePrefabs), vị trí x, vị trí y, vị trí bắt đầu. 
    private void PlaceTile(string tileType, int x, int y, Vector3 startPos)
    {
        int tileIndex = int.Parse(tileType);
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();
        // gán vị trí bắt đầu cho tile tiếp theo theo x, y, parent là map
        newTile.Setup(new Point(x, y), new Vector3(startPos.x + TileSize * x, startPos.y - TileSize * y, 0), map);

    }

    //doc data tu file Level trong Resources vào array
    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);
        return data.Split("-");
    }

    // tạo cửa để sinh quái ở tile(Point(0,0))
    private void SpawnPortals()
    {
        blueSpawn = new Point(0, 0);
        Instantiate(bluePortalPrefab, Tiles[blueSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }

    //kiem tra node co nam trong khung Tiles khong?
    public bool InBouns(Point point)
    {
        //kiểm tra nếu giá trị x nhỏ hơn 0 hoặc y <0 thì là nằm ngoài Tiles
        if (Tiles[point].GridPosition.X < 0 || Tiles[point].GridPosition.Y < 0)
        {
            return false;
        }

        return true;
    }
}

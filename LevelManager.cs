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



    public Dictionary<Point, TileScript> Tiles { get; set; }

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


    void Update()
    {

    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();
        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        Vector3 startPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(), x, y, startPos);
            }
        }
        maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        cameraMovement.SetLimits(new Vector3(maxTile.x + TileSize, maxTile.y - TileSize));
        SpawnPortals();
    }

    private void PlaceTile(string tileType, int x, int y, Vector3 startPos)
    {
        int tileIndex = int.Parse(tileType);
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        newTile.Setup(new Point(x, y), new Vector3(startPos.x + TileSize * x, startPos.y - TileSize * y, 0), map);

    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);
        return data.Split("-");
    }

    private void SpawnPortals()
    {
        blueSpawn = new Point(0, 0);
        Instantiate(bluePortalPrefab, Tiles[blueSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileControls : MonoBehaviour
{
    public Tilemap tiles;

    public Tile tile;

    public Tile tile2;

    public Vector3Int location;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tiles.WorldToCell(mp);
            tiles.SetTile(location, tile);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GetT();
        }
        if(Input.GetMouseButtonDown(2))
        {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tiles.WorldToCell(mp);
            if (tile2 == tiles.GetTile<Tile>(location))
            {
                Debug.Log("tile2");
            }

            location.y += 1;

            if (tile2 == tiles.GetTile<Tile>(location))
            {
                Debug.Log("y+1 tile");
            }
        }





        void GetT()
        {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tiles.WorldToCell(mp);

            if (tiles.GetTile(location))
            {
                Debug.Log("tile");
            }
            else
            {
                Debug.Log("no tile");
            }
        }
    }
}

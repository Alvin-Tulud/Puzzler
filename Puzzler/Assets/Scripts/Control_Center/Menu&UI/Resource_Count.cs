using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Count : MonoBehaviour
{
    public GameObject Tile_To_Spawn;
    public int Tile_Count;
    public List<GameObject> Tiles;
    private LayerMask BeltLayerMask;
    private int Next_Tile;
    private int Current_Tile_Count;
    public TextMeshProUGUI Tile_Count_Tracker;

    // Start is called before the first frame update
    void Start()
    {
        Tiles = new List<GameObject>();

        for (int i = 0; i < Tile_Count; i++)
        {
            GameObject g = Instantiate(Tile_To_Spawn, transform.position, transform.rotation);
            Tiles.Add(g);
            g.name = Tile_To_Spawn.name + ": " + i;
            g.SetActive(false);
        }
        Tiles[0].SetActive(true);

        Next_Tile = 1;

        Tile_Count_Tracker.text = Tile_Count.ToString();

        BeltLayerMask = 1 << 8;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D checkTile = Physics2D.Raycast(transform.position, transform.forward, 0.1f, BeltLayerMask);

        if (Next_Tile < Tiles.Count)
        {
            if (!checkTile)
            {
                Tiles[Next_Tile].SetActive(true);
                Next_Tile++;
                
            }
            gameObject.layer = 9;
        }
        else if (Next_Tile == Tiles.Count && Input.GetMouseButtonUp(0) && !checkTile)
        {
            gameObject.layer = 0;
        }

        RaycastHit2D[] currentCount = Physics2D.RaycastAll(transform.position, transform.forward, 0.1f, BeltLayerMask);
        Current_Tile_Count = currentCount.Length;

        if (Current_Tile_Count == 2)
        {
            Tile_Count_Tracker.text = ((Tile_Count + 1 - Next_Tile) + 1).ToString();
        }

        else if (Current_Tile_Count == 1)
        {
            Tile_Count_Tracker.text = (Tile_Count + 1 - Next_Tile).ToString();
        }

        else
        {
            Tile_Count_Tracker.text = "0";
        }
    }
}

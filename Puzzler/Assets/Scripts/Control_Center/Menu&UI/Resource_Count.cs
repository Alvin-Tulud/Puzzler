using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        //turns the tile on and sets the next tile as usable
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


        //keeps tracks of the count of how many tiles there are
        for(int i = 0; i < Tiles.Count; i++)
        {   
            if (Tiles[i] == null)
            {
                Tiles.RemoveAt(i);
                Next_Tile--;
            }
            else if (Tiles[i].activeInHierarchy && Tiles[i].transform.localToWorldMatrix != gameObject.transform.localToWorldMatrix)
            {
                Tiles.RemoveAt(i);
                Next_Tile--;
            }
        }

        Tile_Count_Tracker.text = Tiles.Count.ToString();
    }

    //Used by Draggable's trashbin logic to increase tile count.
    public void AddTile()
    {
        GameObject g = Instantiate(Tile_To_Spawn, transform.position, transform.rotation);
        Tiles.Add(g);

        g.name = Tile_To_Spawn.name + ": " + (Tiles.Count);
        g.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt_Move_TurnBased : MonoBehaviour, Tile_Interface
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnMove()
    {
        Debug.Log("Belt moves ball");
    }

    public void TurnEffect() //Belts have no effect
    {
        Debug.Log("Belt effect (none)");
    }

}

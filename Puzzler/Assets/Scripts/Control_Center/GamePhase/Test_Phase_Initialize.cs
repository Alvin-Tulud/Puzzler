using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Phase_Initialize : MonoBehaviour
{
    private bool testStart;
    private bool ballsSpawned;
    private Turn_Clicker clicker;
    private GameObject[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        //when the testStart is enabled turn on the turn clicker script in turnDirector 
        //turn off when balls are done or have been destroyed
        clicker = GameObject.FindWithTag("Turn_DIrector").GetComponent<Turn_Clicker>();
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if(testStart && !ballsSpawned)
        {
            clicker.enabled = true;
            ballsSpawned = true;

            foreach (GameObject g in spawners)
            {
                g.GetComponent<Spawner_Start>().TurnEffect();
            }
        }
        
        if (!testStart)
        {
            clicker.enabled = false;
            ballsSpawned = false;

            foreach(GameObject g in spawners)
            {
                g.GetComponent<Spawner_Start>().setIsSpawned(false);
            }
            foreach (GameObject g in GameObject.FindGameObjectsWithTag(""))
            {
                Destroy(g);
            }
        }
    }

    public void state(bool state) { testStart = state; }
}

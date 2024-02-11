using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Phase_Initialize : MonoBehaviour
{
    private bool testStart;
    private bool ballsSpawned;
    private Turn_Clicker clicker;
    private GameObject[] spawners;
    private GameObject[] goals;
    // Start is called before the first frame update
    void Start()
    {
        //when the testStart is enabled turn on the turn clicker script in turnDirector 
        //turn off when balls are done or have been destroyed
        clicker = GameObject.FindWithTag("Turn_DIrector").GetComponent<Turn_Clicker>();
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        goals = GameObject.FindGameObjectsWithTag("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        if(testStart && !ballsSpawned)
        {   
            foreach (GameObject g in goals)
            {
                g.GetComponent<Goal_End>().ballsReset();
            }
            foreach (GameObject g in spawners)
            {
                g.GetComponent<Spawner_Start>().TurnEffect();
                g.GetComponent<Spawner_Start>().showFlask(false);
            }

            clicker.enabled = true;
            ballsSpawned = true;
        }
        
        if (!testStart)
        {
            foreach(GameObject g in spawners)
            {
                g.GetComponent<Spawner_Start>().setIsSpawned(false);
                g.GetComponent<Spawner_Start>().showFlask(true);
            }
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ball_Parent"))
            {
                Destroy(g);
            }

            clicker.enabled = false;
            ballsSpawned = false;
        }
    }

    public void state(bool state) { testStart = state; }
}

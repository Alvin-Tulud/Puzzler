using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Visualizer : MonoBehaviour
{
    private Goal_End goal_end;
    public List<string> Goal_Colors = new List<string>(4);

    // Start is called before the first frame update
    void Start()
    {
        goal_end = gameObject.GetComponent<Goal_End>();
        Goal_Colors = goal_end.getGoalColors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

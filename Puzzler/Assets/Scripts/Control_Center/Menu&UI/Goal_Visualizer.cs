using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Visualizer : MonoBehaviour
{
    private Goal_End goal_end;
    public List<string> Goal_Colors = new List<string>(4);
    private GameObject Display_Flask;
    private Ball_Modify Flask_Script;

    // Start is called before the first frame update
    void Start()
    {
        goal_end = gameObject.GetComponent<Goal_End>(); //get the goal end script (sibling of this script)
        Goal_Colors = goal_end.getGoalColors(); //get the colors from the goal end script
        GameObject g = GameObject.FindWithTag("Ball_Menu");
        Display_Flask = g.transform.GetChild(0).gameObject;
        Flask_Script = Display_Flask.GetComponent<Ball_Modify>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //on click down
        {
            for(int i=0; i < Goal_Colors.Count; i++)
            {
                if(Goal_Colors[i] != null)
                {
                    string layer = Goal_Colors[i];
                    Flask_Script.setColorMod(i,layer);
                    Debug.Log("Set layer " + i + " to " + layer);
                }
            }
        }

    }
}

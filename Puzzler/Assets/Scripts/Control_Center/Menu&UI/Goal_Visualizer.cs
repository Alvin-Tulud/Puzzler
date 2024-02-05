using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Visualizer : MonoBehaviour
{
    private Goal_End goal_end;
    public List<string> Goal_Colors = new List<string>(4);
    private GameObject Display_Flask;
    private Ball_Modify Flask_Script;

    private Collider2D Clickable_Space;
    private LayerMask Clicker_Mask;

    // Start is called before the first frame update
    void Start()
    {
        goal_end = gameObject.GetComponent<Goal_End>(); //get the goal end script (sibling of this script)
        Goal_Colors = goal_end.getGoalColors(); //get the colors from the goal end script
        GameObject g = GameObject.FindWithTag("Ball_Menu");
        Display_Flask = g.transform.GetChild(0).gameObject;
        Flask_Script = Display_Flask.GetComponent<Ball_Modify>();

        Clickable_Space = gameObject.transform.Find("GoalClicker").GetComponent<Collider2D>(); //collider for clicking on goal
        Clicker_Mask = 1 << 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get the mouse position

        if (Input.GetMouseButtonDown(0)) //on click down
        {
            if (Clickable_Space == Physics2D.OverlapPoint(mousePos, Clicker_Mask))//figure out how to make it so the tiles cant be placed on eachother
            {
                Flask_Script.setColorModList(Goal_Colors);
            }

                

            
        }

    }
}

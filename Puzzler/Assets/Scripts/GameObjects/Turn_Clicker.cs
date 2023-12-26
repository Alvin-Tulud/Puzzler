using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn_Clicker : MonoBehaviour
{

    public int turnCounter; //Counts the number of elapsed turns, updates to this tell the factory to move
    public Button clickerButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = clickerButton.GetComponent<Button>();
        btn.onClick.AddListener(IncrementOnClick);
    }

    void IncrementOnClick()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}

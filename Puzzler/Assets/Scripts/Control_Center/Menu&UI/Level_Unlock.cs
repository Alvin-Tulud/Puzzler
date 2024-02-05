using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Unlock : MonoBehaviour
{
    //Static classes and class members: Static class members can be accessed from anywhere without having to reference a specific object.
    public static Level_Unlock Instance;

    public List<bool> isWon = new List<bool>();
    public List<int> levelsCleared = new List<int>();
    public List<GameObject> levelButtons = new List<GameObject>();
    //maybe do a dictionary or something

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //do the level stuff here 
    //hold bools for buttons and enable them when winscreen pops up for previous level

    //make a tag for each button level_i so its easy to do unlock level_ i+1 .getcomponentbutton = interactable find gameobject withtag("level_" + x) 
    private void Start()
    {//unlock the levels here
        if (Level_Unlock.Instance != null)
        {//do a foreach try catch

        }
    }

    public void Update()
    {//check if winscreen triggered
        try
        {
            if (Level_Unlock.Instance != null && 
                GameObject.FindGameObjectWithTag("WinScreen").GetComponent<WinScreen>().playerWon() &&
                !levelsCleared.Contains(SceneManager.GetActiveScene().buildIndex - 9))
            {
                levelsCleared.Add(SceneManager.GetActiveScene().buildIndex - 9);
                isWon.Add(true);
            }
        }
        catch(System.Exception e)
        {
            //balls
        }
    }
}

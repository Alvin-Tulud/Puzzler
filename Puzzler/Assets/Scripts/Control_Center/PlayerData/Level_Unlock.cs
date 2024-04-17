using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Level_Unlock : MonoBehaviour
{
    //Static classes and class members: Static class members can be accessed from anywhere without having to reference a specific object.
    public static Level_Unlock Instance;

    public List<bool> isWon = new List<bool>();
    private List<int> levelsCleared = new List<int>();
    private List<GameObject> levelButtons = new List<GameObject>();
    //maybe do a dictionary or something

    private int currentscene;

    private void Awake()
    {//https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#634f8281edbc2a65c86270cc
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < 16; i++)
        {
            levelButtons.Add(null);
        }

        saveData();
        readData();
    }

    //do the level stuff here 
    //hold bools for buttons and enable them when winscreen pops up for previous level

    //make a tag for each button level_i so its easy to do unlock level_ i+1 .getcomponentbutton = interactable find gameobject withtag("level_" + x) 

    public void Update()
    {//check if winscreen triggered
        if (Level_Unlock.Instance != null)
        {
            try//levelwon here
            {
                if (!levelsCleared.Contains(SceneManager.GetActiveScene().buildIndex - 9) && GameObject.FindGameObjectWithTag("WinScreen").activeInHierarchy)//put level in list
                {
                    levelsCleared.Add(SceneManager.GetActiveScene().buildIndex - 9);
                    isWon.Add(false);
                }

                if (GameObject.FindGameObjectWithTag("WinScreen").GetComponent<WinScreen>().playerWon())//check if player won
                {
                    isWon[SceneManager.GetActiveScene().buildIndex - 9 - 1] = true;
                }

                saveData();
            }
            catch (System.Exception e)
            {
                //balls
            }

            try//unlock level on scelet
            {

                for (int i = 0; i < 16; i++)
                {
                    int sceneMath = (i + 1 + ((SceneManager.GetActiveScene().buildIndex - 1) * 16));
                    GameObject g = GameObject.FindGameObjectWithTag("level_" + sceneMath); //g.GetComponent<Button>().interactable = true;
                    if (!levelButtons.Contains(g))//gets the buttons
                    {
                        levelButtons[i] = g;
                    }

                    try
                    {
                        //Debug.Log(sceneMath);
                        if (isWon[sceneMath - 2])//unlocks button
                        {
                            levelButtons[i].GetComponent<Button>().interactable = true;
                        }
                    }
                    catch(System.Exception e)
                    {
                        //Debug.Log("bruh: " + e);
                    }

                    if (currentscene != SceneManager.GetActiveScene().buildIndex || !GameObject.FindGameObjectWithTag("level_" + sceneMath).activeInHierarchy)//clear on scene switch
                    {
                        for (int j = 0; j < levelButtons.Count; j++)
                        {
                            levelButtons[j] = null;
                        }
                    }
                    currentscene = SceneManager.GetActiveScene().buildIndex;
                }
            }
            catch (System.Exception e)
            {
                //Debug.Log("egg: " + e);
            }
        }
    }

    public List<bool> getisWon()
    {
        return isWon;
    }

    public List<int> getLevelsCleared()
    {
        return levelsCleared;
    }

    public void setIsWon(List<bool> isWon)
    {
        this.isWon = isWon;
        saveData();
    }

    public void setLevelsCleared(List<int> levelsCleared)
    {
        this.levelsCleared = levelsCleared;
        saveData();
    }

    public void saveData()
    {
        PlayerPrefs.SetString("isWon_count", isWon.Count.ToString("D2"));

        for (int i = 0; i < isWon.Count; i++)
        {
            if (isWon[i])
            {
                PlayerPrefs.SetString("isWon_count" + i.ToString("D2"), 1.ToString("D2"));
            }
            else
            {
                PlayerPrefs.SetString("isWon_count" + i.ToString("D2"), 0.ToString("D2"));
            }
        }

        PlayerPrefs.Save();
    }

    public void readData()
    {
        string filename = Application.persistentDataPath + "/PlayerPrefs";
        string[] filetext = null;


        try
        {
            filetext = File.ReadAllLines(filename);
            int info = 0;
            string numinfo = null;


            Debug.Log("data read");


            for (int i = 0; i < filetext.Length; i++)
            {
                numinfo = filetext[i].Substring(filetext[i].Length - 2, 2);
                int.TryParse(numinfo, out info);
                Debug.Log(filetext[i] + "||" + info);

                if(info == 1)
                {
                    isWon.Add(true);
                }
                else
                {
                    isWon.Add(false);
                }
            }
            for (int i = 0; i < isWon.Count; i++)
            {
                isWon[i] = true;
            }
        }
        catch (System.IO.IsolatedStorage.IsolatedStorageException e)
        {
            //i dont make errors
        }
    }
}

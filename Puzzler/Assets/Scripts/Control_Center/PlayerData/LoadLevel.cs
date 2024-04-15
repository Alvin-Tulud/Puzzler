using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadLevel : MonoBehaviour
{
    public TMP_Text levelCode;
    public Level_Unlock unlockScript;
    public List<bool> isWon = new List<bool>();
    public List<int> levelsCleared = new List<int>();
    string scrambleCode = "43895F6v7n897B59N8H6Vb7n6RVBb5vb67NRVb8o568J7TBTty7R7B87N9y7gM987NTr5V4EV56NOI9B7896rvb7BH6V54bre6BR6895t078b670V567brRF8Tfgno";
    //                     1234567891123456789212345678931234567894123456789512345678961234567897123456789812345678991234567809123456789


    string path;

    private void Start()
    {
        unlockScript = GameObject.FindWithTag("Level_Unlocker").GetComponent<Level_Unlock>();
        path = Application.persistentDataPath;
    }

    public void getInput(string code)
    {
        //do comparison
        Debug.Log(code);
        int level = 0;

        //first check if first 2 chars are ints
        if (int.TryParse(code.Substring(0, 2),out level))
        {

            //check if next 2 chars coencide with the scramble position
            if (scrambleCode.Substring(level - 1, 2).CompareTo(code.Substring(2, 2)) == 0)
            {
                if (level >= unlockScript.getisWon().Count)
                {
                    isWon = unlockScript.getisWon();
                    levelsCleared = unlockScript.getLevelsCleared();

                    for (int i = 0; i < isWon.Count; i++)
                    {
                        isWon[i] = true;
                    }


                    for (int i = isWon.Count; i < level; i++)
                    {
                        isWon.Add(true);
                        levelsCleared.Add(i);
                    }


                    unlockScript.setIsWon(isWon);
                    unlockScript.setLevelsCleared(levelsCleared);
                }
                //if level code is less than levels already unlocked do nothing
                //call unlock script and add the levels to iswon and levelscleared
            }
            else
            {
                Debug.Log("cannot find in list");
            }
        }
        else
        {
            Debug.Log("invalid int");
        }
    }
}

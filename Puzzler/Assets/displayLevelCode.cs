using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class displayLevelCode : MonoBehaviour
{
    TMP_Text levelCode;
    int levelIndex;
    string displayCode;
    string scrambleCode = "43895F6v7n897B59N8H6Vb7n6RVBb5vb67NRVb8o568J7TBTty7R7B87N9y7gM987NTr5V4EV56NOI9B7896rvb7BH6V54bre6BR6895t078b670V567brRF8Tfgno";
    //                     1234567891123456789212345678931234567894123456789512345678961234567897123456789812345678991234567809123456789

    private void Awake()
    {
        levelCode = GetComponent<TMP_Text>();
        levelIndex = SceneManager.GetActiveScene().buildIndex - 9;

        displayCode = "Level Code: ";
        displayCode += levelIndex.ToString("D2");
        displayCode += scrambleCode.Substring(levelIndex-1,2);

        levelCode.text = displayCode;
    }
}

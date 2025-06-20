using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This entire script is mostly used to switch between scenes, and serves as a scene manager of sorts.
public class menuScreen : MonoBehaviour
{
    static bool hasPlayed = false;
    private void Start()
    {
    }
    public void goToGameSelect(int world)
    {
        //This method will switch the current scene to the game selection screen.
        SceneManager.LoadScene(world);
        //if (!hasPlayed) { FactoryRunAudio.StartMusic(); hasPlayed = true; }

    }

    public void goToTutorial()
    {
        SceneManager.LoadScene(58);
        //if (!hasPlayed) { FactoryRunAudio.StartMusic(); hasPlayed = true; }
    }

    public void goToCredits()
    {
        //This method will switch the current scene to the credits scene.
        SceneManager.LoadScene(8);
        //if (!hasPlayed) { FactoryRunAudio.StartMusic(); hasPlayed = true; }
    }

    public void goToControls()
    {
        //This method will switch the current scene to the controls scene.
        SceneManager.LoadScene(9);
        //if (!hasPlayed) { FactoryRunAudio.StartMusic(); hasPlayed = true; }
    }

    public void goBackMenu()
    {
        //This method will switch the current scene to the main menu scene.
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        //This method will switch the current scene to the end of the game.
        Application.Quit();
    }

    public void resetLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void nextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 58)//if at tutorial go to level 1 after
        {
            SceneManager.LoadScene(10);
        }
        else if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings && (SceneManager.GetActiveScene().buildIndex - 9) % 16 != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings && (SceneManager.GetActiveScene().buildIndex - 9) % 16 == 0)
        {
            goToGameSelect(((SceneManager.GetActiveScene().buildIndex - 9) / 16) + 1);//goes to next world
        }
        else
        {
            goToCredits();
        }
    }


    //Starting from scene 4 is where all of the levels are loaded (starting at level 1)
    public void gotoLevel(int levelNum)
    {
        //This method will switch the current scene to the main menu scene.
        SceneManager.LoadScene(levelNum);
    }

}

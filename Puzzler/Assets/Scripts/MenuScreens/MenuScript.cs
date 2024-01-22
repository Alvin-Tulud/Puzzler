using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This entire script is mostly used to switch between scenes, and serves as a scene manager of sorts.
public class menuScreen : MonoBehaviour
{
    public void goToGameSelect()
    {
        //This method will switch the current scene to the game selection screen.
        SceneManager.LoadScene(1);
    }

    public void goToCredits()
    {
        //This method will switch the current scene to the credits scene.
        SceneManager.LoadScene(2);
    }

    public void goToControls()
    {
        //This method will switch the current scene to the controls scene.
        SceneManager.LoadScene(3);
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
}

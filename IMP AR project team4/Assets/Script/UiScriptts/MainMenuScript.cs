using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   //public GameObject LevelMenu;
   //public GameObject SettingsMenu;

    //call this method when "play" is pressed
    /* public void PlayGame()
    {
        LevelMenu.SetActive(true);
    }

    //call this method to go to settings menu
    public void Settings()
    {
        SettingsMenu.SetActive(true);
    }
    */

    //call this method when "quit" is pressed
    public void QuitGame()
    {
        //run this code only in editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //stop play mode
#endif
        Application.Quit(); //whe running as build game
}

}

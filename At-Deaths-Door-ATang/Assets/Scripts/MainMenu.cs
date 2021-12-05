/*
 * Made by: Adam Tang
 * Date Created: 12/4/2021
 * Date Modified: 12/4/2021
 * Description: Script to control actions in the main menu.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Greybox");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

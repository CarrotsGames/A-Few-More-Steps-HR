using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    int toggle;
    public GameObject settings;
    public GameObject pauseMenu;
    private GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        if (pauseMenu == null)
        {
            Debug.LogError("Pause menu is null, im on the canvas!!!");
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            toggle++;
            PauseGame();
        }
    }
    void PauseGame()
    {
        if(toggle < 2)
        {
            pauseMenu.SetActive(true);
            gameManager.GetComponent<GameManager>().StopPlayerControls();
        }
        else
        {
            ResumeGame();
        }

    }
    // the purpose of this is so it can be called from other scripts(eg resume button)
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        toggle = 0;
        gameManager.GetComponent<GameManager>().ResumePlayerControls();
    }
    // As of right now it will close the game.
    // in the future this will return player to main menu
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
   public void OpenSettings()
    {
        settings.SetActive(true);
        pauseMenu.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour

{

    // ASSIGNMENT
    [SerializeField] private GameObject pauseMenuPanel;

    private bool isPaused = false;

    // Check if the player presses the "Escape" key (or any key you choose).    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            //Show Pause Panel
            pauseMenuPanel.SetActive(true);

            //Freeze game time
            Time.timeScale = 0f;
            //Freeze audio --

            //Set isPaused to true
            isPaused = true;

        }
    }

    public void ResumeGame(){

        // Hide Pause panel
        pauseMenuPanel.SetActive(false);

        //Unfreeze game time
        Time.timeScale= 1f;

        //Set isPaused to false
        isPaused = false;


    }

    public void RestartLevel(){
        //Unfreeze game time
        Time.timeScale= 1f;

        //Set isPaused to false
        isPaused = false;
        
        SceneManager.LoadScene("SampleScene");

    }

    public void QuitGame(){

        // Show Main Menu
        SceneManager.LoadScene("MainMenuScene");
    }
}

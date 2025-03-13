using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        //Load the scene and build index + 1
        //GameManager.instance.RestartLevel();
        //Time.timeScale = 0f; // Ensure game time is resumed
        if(GameManager.instance !=null){
        GameManager.instance.ResetTimer();
        GameManager.instance.ResetGame();


        }
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene(1);

    }

    //Exit game
    public void QuitGame(){
        Debug.Log("Application Exits");
        Application.Quit();
    }


}

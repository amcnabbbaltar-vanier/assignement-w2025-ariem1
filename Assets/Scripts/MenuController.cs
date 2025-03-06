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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    //Exit game
    public void QuitGame(){
        Debug.Log("Application Exits");
        Application.Quit();
    }


}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // If paused, resume
            }
            else
            {
                PauseGame(); // If not paused, pause the game
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true); // Show pause menu
        Time.timeScale = 0f; // Freeze time
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); // Hide pause menu
        Time.timeScale = 1f; // Resume time
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Resume time before restarting
        isPaused = false; // Unpause

        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame(); // Reset game stats
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart scene
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure game time is resumed
        isPaused = false; // Unpause

        SceneManager.LoadScene("MainMenuScene"); // Load main menu
    }
}

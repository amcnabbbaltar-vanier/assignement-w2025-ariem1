using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Make sure to include the TextMeshPro namespace

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public GameObject gameOverPanel;

    public void Start()
    {
        gameOverPanel.SetActive(true);
        if (GameManager.instance)
        {
            scoreText.text = "Score: " + GameManager.instance.score.ToString();

            timerText.text = "Final Time: " + GameManager.instance.timeElapsed.ToString("F2");
        }
       
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Make sure to include the TextMeshPro namespace

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI endSceneText;


    public GameObject gameOverPanel;

    public void Start()
    {
        gameOverPanel.SetActive(true);
        if (GameManager.instance)
        {

            if (GameManager.instance.youLose)
            {
                endSceneText.text = "You Lose";
            }
             else
            {
                endSceneText.text = "You Win!";
            }
            scoreText.text = "Score: " + GameManager.instance.score.ToString();

            timerText.text = "Final Time: " + GameManager.instance.timeElapsed.ToString("F2");
        }

    }
    public void RestartGame()
    {
        if (GameManager.instance)
        {
            GameManager.instance.playerHealth = 3;
            GameManager.instance.score = 0;
            GameManager.instance.cubesCollected = 0;
            GameManager.instance.timeElapsed = 0f;



            SceneManager.LoadScene(0);


        }
    }
}

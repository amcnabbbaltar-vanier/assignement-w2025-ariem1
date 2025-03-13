using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerHealth = 3; // Stores player health across levels
    public int score = 0; // Score across levels
    public Text healthText;
    public Text scoreText;

    public Text timerText;

    public Text cubeText;

    public float timeElapsed = 0f;
    private bool isRunning = true;

    public int currentLevel;

    public int requiredScoreCube = 3;

    public int cubesCollected = 0;

    public TMP_Text  endSceneText;
    public bool youLose = false;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene reload
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    private void Start()
    {
        FindUIElements();
        UpdateHealthUI();
        UpdateScoreUI();
        UpdateTimerUI();
        UpdateCubeCollectedUI();

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Ensure UI is reassigned after scene loads
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIElements();
        UpdateHealthUI();
        UpdateScoreUI();
        UpdateTimerUI();
        UpdateCubeCollectedUI();


        currentLevel = scene.buildIndex;
    }

    private void FindUIElements()
    {
        healthText = GameObject.Find("HealthText")?.GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText")?.GetComponent<Text>();
        timerText = GameObject.Find("TimerText")?.GetComponent<Text>();
        cubeText = GameObject.Find("CubeText")?.GetComponent<Text>();

    }

    // public void GetCurrentScene(){
    //     currentLevel = SceneManager.GetActiveScene().buildIndex;
    //     Debug.Log(currentLevel + "current level");
    // }

    public void ReduceHealth(int amount)
    {
        playerHealth -= amount;
        UpdateHealthUI();
    }

    public void CollectCube()
    {
        cubesCollected += 1;
        UpdateCubeCollectedUI();

    }



    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public bool MinimumCubesCollected()
    {
            //Debug.Log("Cubes colected " + cubesCollected);


        if(cubesCollected >= requiredScoreCube){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            cubesCollected = 0;
            return true;

           }

        return false;
                
            }

public void UpdateHealthUI()
{
    if (healthText != null)
    {
        healthText.text = "Health: " + playerHealth;
    }
}

public void UpdateScoreUI()
{
    if (scoreText != null)
    {
        scoreText.text = "Score: " + score;
    }
}

public void UpdateTimerUI()
{
    if (timerText != null)
    {
        timerText.text = "Timer: " + timeElapsed.ToString("F2");
    }
}

public void FallDetected()
{
    //playerHealth = 3;
    score = 0;
    playerHealth -= 1;
    cubesCollected = 0;
    if (playerHealth == 0)
    {
        ResetGame();
    }
    else
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the scene

}

public void UpdateCubeCollectedUI()
{
     if (cubeText != null)
    {
        cubeText.text = "Collect 3 green cubes to go to pass the portal. \nGreen cubes collected: " + cubesCollected + " / 3";
    }
}

public void ResetGame()
{
    playerHealth = 3;
    score = 0;
    cubesCollected = 0;
    //UpdateCubeCollectedUI();
    //ResetTimer();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the scene
}

public void GameOver()
{
    if (playerHealth == 0)
    {
        // GameObject gameOverController = GameObject.Find("VictoryPanel");
        // if (gameOverController)
        // {
        //     gameOverController.GetComponent<GameOverController>().ShowGameOver();
        // }
        youLose = true;
        SceneManager.LoadScene("EndScene");


    }
}

private void Update()
{
    if (isRunning)
    {
        timeElapsed += Time.deltaTime; // Timer keeps counting
        UpdateTimerUI();
    }
}

public void StopTimer()
{
    isRunning = false;
    Debug.Log("Final Time: " + timeElapsed.ToString("F2"));
}

public void ResetTimer()
{
    timeElapsed = 0f; // Reset time when starting a new game
    isRunning = true;
}
}


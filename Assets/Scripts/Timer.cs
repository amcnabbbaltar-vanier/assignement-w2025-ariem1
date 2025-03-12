using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    private void Update()
    {
        if (GameManager.instance != null)
        {
            timerText.text = "Time: " + GameManager.instance.timeElapsed.ToString("F2"); // Display time
        }
    }

    public void StopTimer()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.StopTimer();
            timerText.text = "Final Time: " + GameManager.instance.timeElapsed.ToString("F2");
        }
    }
}

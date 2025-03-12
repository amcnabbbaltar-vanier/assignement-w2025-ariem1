using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText; // UI text to display health

    private void Start()
    {
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        healthText.text = "Health: " + GameManager.instance.playerHealth;
    }
}

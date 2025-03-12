using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           

            // Only restart if player still has health left
            if (GameManager.instance.playerHealth > 0)
            {
               
                // GameManager.instance.ResetGame();
                // GameManager.instance.ReduceHealth(1);
                 GameManager.instance.FallDetected();  


            }
          
        }
    }
}

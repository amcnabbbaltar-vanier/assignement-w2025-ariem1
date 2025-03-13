using UnityEngine;

public class RedTrap : MonoBehaviour
{
    public GameObject trapEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {

                // Particle Effect
                   if (trapEffectPrefab != null)
            {
                Instantiate(trapEffectPrefab, transform.position, Quaternion.identity);
            }

                //     playerHealth.TakeDamage(1); // Reduce health by 1
                GameManager.instance.ReduceHealth(1); // Reduce 
                // health
                 GameManager.instance.GameOver();

            }
        }
    }

    private void AddTraps(){

        if(GameManager.instance.currentLevel > 1){


        }
    }
}

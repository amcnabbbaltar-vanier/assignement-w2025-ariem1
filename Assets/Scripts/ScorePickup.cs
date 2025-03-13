using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{

    public GameObject particleEffectPrefab; // Assign the particle effect prefab in the Inspector

    public int scoreValue = 50;

    public float effectDuration = 2f;

    public float rotationSpeed = 10f;
    public float hoverSpeed = 2f;
    public float hoverHeight = 0.1f;
    private Vector3 startPosition;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // Spawn the particle effect at the collectible's position
            if (particleEffectPrefab != null)
            {
                GameObject effect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);

                Destroy(effect, effectDuration); //Destroy the effect after `effectDuration` seconds


            }


            GameManager.instance.CollectCube();

            GameManager.instance.AddScore(scoreValue);

            Destroy(gameObject);

        }
    }

    void Update()
    {
        // Rotate around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        //Debug.Log(startPosition.y);
        
        startPosition.y = 1;

        // Hover up and down using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * (hoverHeight / 2);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

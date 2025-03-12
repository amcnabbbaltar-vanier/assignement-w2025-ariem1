using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float powerUpDuration = 0.3f;

    public float rotationSpeed = 20f;
    public float hoverSpeed = 2f;
    public float hoverHeight = 0.5f;
    private Vector3 startPosition;

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player")){

            Debug.Log("triggered");

            CharacterMovement player = other.gameObject.GetComponent<CharacterMovement>();

            if(player != null){
                StartCoroutine(player.ActivateDoubleJump(powerUpDuration));
            }

        }

        Destroy(gameObject);
    }

    void Start()
    {
        startPosition = transform.position; // Store initial position
    }

    void Update()
    {
        // Rotate around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Hover up and down using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * (hoverHeight/2);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

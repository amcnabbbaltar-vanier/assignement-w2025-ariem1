using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{

    public int scoreValue = 50;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){

            GameManager.instance.AddScore(scoreValue);

            Destroy(gameObject);

        }
    }
}

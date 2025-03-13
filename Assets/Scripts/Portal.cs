using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

           if(GameManager.instance.MinimumCubesCollected()){
            Debug.Log("Cubes colected " + GameManager.instance.cubesCollected);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
           }



        }
    }
}

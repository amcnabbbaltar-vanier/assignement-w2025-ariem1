using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject scoreCube; // Array of collectibles/power-ups
    public Transform[] spawnPoints; // Predefined spawn locations

    public int numberOfCollectibles; // How many to spawn

    public static GameManager instance;

    public GameObject[] speedCube ; // Array of speed cubes
    public GameObject[] jumpCube ; // Array of speed cubes




    private void Start()
    {
        Invoke("SpawnCollectibles", 0.5f); // Delay to ensure GameManager is initialized
    }

  void SpawnCollectibles()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("GameManager is missing!");
            return;
        }

        int level = GameManager.instance.currentLevel;
        
        // if (level == 2)
        // {
            numberOfCollectibles = level; // Adjust collectible count for Level 2
        //}

        Debug.Log("Spawning " + numberOfCollectibles + " collectibles in Level " + level);

        for (int i = 0; i < numberOfCollectibles; i++)
        {
           
            int randomSpawn = Random.Range(0, spawnPoints.Length);


            //Instantiate score cube at random spawn point
            Instantiate(scoreCube, spawnPoints[randomSpawn].position, Quaternion.identity);
        }
    }
}

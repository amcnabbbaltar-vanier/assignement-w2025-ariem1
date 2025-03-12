using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectibles; // Array of collectibles/power-ups
    public Transform[] spawnPoints; // Predefined spawn locations

    public int numberOfCollectibles; // How many to spawn

    public static GameManager instance;


    private void Start()
    {
        SpawnCollectibles();
    }

    void SpawnCollectibles()
    {

        int level = GameManager.instance.currentLevel;
        if (level == 2)
        {

            numberOfCollectibles = 2;
        }

        Debug.Log(numberOfCollectibles);

        for (int i = 0; i < numberOfCollectibles; i++)
        {
            int randomCollectible = Random.Range(0, collectibles.Length);
            int randomSpawn = Random.Range(0, spawnPoints.Length);

            Instantiate(collectibles[randomCollectible], spawnPoints[randomSpawn].position, Quaternion.identity);
        }
    }
}

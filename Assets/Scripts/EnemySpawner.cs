using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

     public GameObject enemyPrefab; 
    public float posY; 
    public float maxPosX, minPosX; 
    public float height;
    public float cooldown;


    private float remainingCooldown;

    private void Start()
    {
        remainingCooldown = cooldown;
        SpawnEnemy();
    }

    void Update()
    {
        remainingCooldown -= Time.deltaTime; 
        if(remainingCooldown < 0)
        {
            print("Cooldown complete");
            SpawnEnemy();
            remainingCooldown = cooldown;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minPosX, maxPosX), height ,posY);
        print("Spawn at " + spawnPos);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

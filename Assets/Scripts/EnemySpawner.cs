using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

     public GameObject enemyPrefab; 
    public float posX; 
    public float maxPosY, minPosY; 
    public float height;
    public float cooldown;


    private float remainingCooldown;

    void Start()
    {
        remainingCooldown = cooldown;
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
        Vector3 SpawnPos = new Vector3(Random.Range(minPosY, maxPosY), height ,posX);
        
    }
}

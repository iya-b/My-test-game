using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    public float spawnDelay = 5.0f;

    [SerializeField]
    public Enemy enemyPrefab;

    public static int maxEnemyCount = 5;

    public int currentEnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, spawnDelay);
    }


    void InvokeRepeating()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            Enemy newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as Enemy;
            newEnemy.Target = GameObject.FindGameObjectWithTag("Player").transform;
            currentEnemyCount += 1;
        }
    }

}

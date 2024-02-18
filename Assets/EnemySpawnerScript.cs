using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyShipPrefab;
    public static EnemySpawnerScript enemySpawner;

    public float xPosMax = 2.75f;
    public float xPosMin = -2.75f;
    public float yPosMax = 7f;
    public float yPosMin = 5f;

    float spawnInterval;
    //private int currentEnemyShip = 0;

    int enemyCount;

    private void Awake()
    {
        if (enemySpawner == null)
        {
            enemySpawner = this;
        }

        else if (enemySpawner != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(1, 3);

        enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0 && enemyCount < 5)
        {
            float spawnXPosition = Random.Range(xPosMin, xPosMax);
            float spawnYPostion = Random.Range(yPosMin, yPosMax);

            GameObject enemyShip = (GameObject)Instantiate(enemyShipPrefab);
            enemyCount++;

            enemyShip.transform.position = new Vector2(spawnXPosition, spawnYPostion);

            spawnInterval = Random.Range(1, 3);
        }

        
    }
}

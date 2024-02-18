using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class BossControllerScript : MonoBehaviour
{
    public static BossControllerScript bossController;

    float speed;

    bool goLeft = true;

    float xPosMin = -2.35f;
    float xPosMax = 2.45f;

    public GameObject enemyProjectile;
    public GameObject enemyProjectilePosition;
    float fireInterval = 1f;
    float waitToFire;

    GameObject player;

    int random;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        waitToFire = fireInterval;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player = GameObject.Find("Player1");
        }

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            random = Random.Range(1, 100);

            if (random <= 50)
            {
                player = GameObject.Find("Player1");
            }

            if (random <= 100 && random > 50)
            {
                player = GameObject.Find("Player2");
            }
        }

        

        waitToFire -= Time.deltaTime;

        if (waitToFire <= 0)
        {
            if(player != null)
            {
                FireProjectile();
            }         
            waitToFire = fireInterval;
        }


        Vector2 position = transform.position;

        if (goLeft)
        {
            GoLeft(position);

            if (position.x < xPosMin)
            {
                goLeft = false;
            }
        }
        else
        {
            GoRight(position);

            if (position.x > xPosMax)
            {
                goLeft = true;
            }
        }




    }

    void GoLeft(Vector2 position)
    {
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    void GoRight(Vector2 position)
    {
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    void FireProjectile()
    {
        GameObject enemyprojectile = Instantiate(enemyProjectile);
        enemyProjectile.transform.position = enemyProjectilePosition.transform.position;
        //Debug.Log("Fire! " + enemyProjectile.transform.position + " | " + enemyProjectilePosition.transform.position);

    }
}

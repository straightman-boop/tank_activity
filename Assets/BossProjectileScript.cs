using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BossProjectileScript : MonoBehaviour
{
    public GameObject target;
    float speed = 1f;

    Rigidbody2D rb;

    float tracking = 2f;
    bool isTracking = true;

    int random;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            target = GameObject.Find("Player1");
        }

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            random = Random.Range(1, 100);

            Debug.Log(random);

            if (random <= 50)
            {
                target = GameObject.Find("Player1");
            }

            if (random <= 100 && random > 50)
            {
                target = GameObject.Find("Player2");
            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(target);

        //tracking -= Time.deltaTime;

        if (target != null)
        {
            Vector2 position = target.transform.position - transform.position;
            position.Normalize();
            rb.position += position * speed * Time.deltaTime;
        }

        if(target == null)
        {
            Destroy(gameObject);
        }
        

        if (GameController.gameController.isGamOver == true || GameController.gameController.gameWin == true)
        {
            Destroy(gameObject);
        }

    }
}

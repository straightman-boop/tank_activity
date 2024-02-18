using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    float speed;
    public GameObject Explosion;

    public GameObject Healthdrop;

    public GameObject Speeddrop;

    public GameObject Shielddrop;


    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            PlayerStatsScript.playerStats.UpdateScore();

            Vector2 expos = collision.transform.position;

            float chance = Random.Range(1f, 10f);
            //Debug.Log(chance);

            if (chance <= 2)
            {
                GameObject healthDrop = Instantiate(Healthdrop);
                healthDrop.transform.position = expos;
            }

            if (chance <= 5 && chance > 2)
            {
                GameObject speedDrop = Instantiate(Speeddrop);
                speedDrop.transform.position = expos;
            }
            
            if (chance <= 10 && chance > 5)
            {
                GameObject shieldDrop = Instantiate(Shielddrop);
                shieldDrop.transform.position = expos;
            }



        }


        if (collision.tag == "Enemy" || collision.tag == "enemyProjectile")
        {
            if (collision.tag == "Enemy" && collision.tag != "enemyProjectile")
            {
                GameController.gameController.ShipDestroyed();
            }

            Vector2 expos = transform.position;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            GameObject explosion = (GameObject)Instantiate(Explosion);
            explosion.transform.position = expos;

        }

        if (collision.tag == "Boss")
        {
            Vector2 expos = transform.position;
            GameObject explosion = (GameObject)Instantiate(Explosion);
            explosion.transform.position = expos;
            Destroy(gameObject);

            GameController.gameController.DecrementBossHealth();
        }

        if (collision.tag == "Meteors")
        {
            Vector2 expos = transform.position;
            GameObject explosion = (GameObject)Instantiate(Explosion);
            explosion.transform.position = expos;
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 9)
        {
            Vector2 expos = collision.transform.position;

            float chance = Random.Range(1f, 10f);
            //Debug.Log(chance);

            if (chance <= 5 && chance > 2)
            {
                GameObject healthDrop = Instantiate(Healthdrop);
                healthDrop.transform.position = expos;
            }

            if (chance <= 2)
            {
                GameObject speedDrop = Instantiate(Speeddrop);
                speedDrop.transform.position = expos;
            }

            if (chance <= 10 && chance > 5)
            {
                GameObject shieldDrop = Instantiate(Shielddrop);
                shieldDrop.transform.position = expos;
            }


        }

    }
}

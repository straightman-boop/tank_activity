using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour
{
    int max_health = 100;
    int health;
    public int projectile_dmg = 5;
    public int ship_dmg = 10;

    public GameObject explosion;

    private void Start()
    {
        health = max_health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyProjectile")
        {
            Vector2 expos = collision.transform.position;
            GameObject explode = Instantiate(explosion);
            explode.transform.position = expos;

            if (health > 0)
            {         
                health -= projectile_dmg;
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }

        if (collision.tag == "Enemy")
        {
            Vector2 expos = collision.transform.position;
            GameObject explode = Instantiate(explosion);
            explode.transform.position = expos;

            Destroy(collision.gameObject);

            if (health > 0)
            {
                health -= ship_dmg;
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

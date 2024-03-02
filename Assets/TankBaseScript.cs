using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBaseScript : MonoBehaviour
{
    public GameObject Explode;

    int max_health = 100;
    int current_health;
    int projectile_dmg = 15;
    int ship_dmg = 20;

    private void Start()
    {
        current_health = max_health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyProjectile" || collision.tag == "Enemy")
        {

            if (collision.tag == "enemyProjectile")
            {
                current_health -= projectile_dmg;
            }

            else if (collision.tag == "Enemy")
            {
                current_health -= ship_dmg;
            }

            Vector2 expos = collision.transform.position;
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(Explode);
            explosion.transform.position = expos;

            if(current_health <= 0)
            {
                Destroy(gameObject);
                GameController.gameController.BaseDestroyed();
            }
        }
    }
}

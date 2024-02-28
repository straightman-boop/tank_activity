using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemyProjectile" || collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUpScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            GameController.gameController.ShieldPickUp();
            Destroy(gameObject);
        }

        if(collision.name == "Player2")
        {
            GameController.gameController.Shield2PickUp();
            Destroy(gameObject);
        }

    }
}

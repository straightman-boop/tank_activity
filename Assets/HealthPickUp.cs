using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    float decay = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        decay -= Time.deltaTime;
        if (decay <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.name == "Player1")
            {
                PickUpHealth();
            }

            else if(collision.name == "Player2")
            {
                PickUpHealth2();
            }


            Destroy(gameObject);
        }
    }

    void PickUpHealth()
    {
        PlayerStatsScript.playerStats.playerLife++;
    }

    void PickUpHealth2()
    {
        Player2Stats.playerStats.playerLife++;
    }
}

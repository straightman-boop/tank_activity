using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    SpriteRenderer sprite;
    PolygonCollider2D box;

    public float speedPowerUp = 6f;
    public float speedDuration = 3f;
    float speedCooldown;
    public bool speedOn;

    bool p1 = false;
    bool p2 = false;

    float decay = 7f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        decay -= Time.deltaTime;
        if(decay <= 0)
        {
            Destroy(gameObject);
        }

        if (speedOn == true)
        {
            speedCooldown -= Time.deltaTime;
            //Debug.Log(speedCooldown);
            if (speedCooldown <= 0)
            {
                speedOn = false;

                if (p1 == true)
                {
                    p1 = false;
                    PlayerMovement.playerController.speed = PlayerMovement.playerController.defSpd;
                    Destroy(gameObject);
                }

                if (p2 == true)
                {
                    p2 = false;
                    Player2Movement.playerController.speed = Player2Movement.playerController.defSpd;
                    Destroy(gameObject);
                }

                //Debug.Log(speedOn);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.name == "Player1")
            {
                IncreaseSpeed("Player1");
                sprite.enabled = false;
                box.enabled = false;
            }

            else if (collision.name == "Player2")
            {
                IncreaseSpeed("Player2");
                sprite.enabled = false;
                box.enabled = false;
            }

        }
        
    }

    public void IncreaseSpeed(string player)
    {
        if (player == "Player1")
        {
            if(p1 == false)
            {
                p1 = true;
                PlayerMovement.playerController.speed = speedPowerUp;
                speedOn = true;
                speedCooldown = speedDuration;
            }
            
        }

        if (player == "Player2")
        {
            if(p2 == false)
            {
                p2 = true;
                Player2Movement.playerController.speed = speedPowerUp;
                speedOn = true;
                speedCooldown = speedDuration;
            }
           
        }
    }


}

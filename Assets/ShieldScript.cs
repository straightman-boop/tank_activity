using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Boss" && collision.tag != "PickUp" && collision.tag != "Enemy")
        Destroy(collision.gameObject);
    }
}

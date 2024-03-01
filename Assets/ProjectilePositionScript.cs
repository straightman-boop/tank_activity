using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePositionScript : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        transform.position = Player.transform.position;

        else if(Player == null)
        {
            Destroy(gameObject);
        }
    }
}

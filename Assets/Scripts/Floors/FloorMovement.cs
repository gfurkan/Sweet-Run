using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    float floorSpeed = 0;
    Rigidbody2D floor;
    GameControl gameControl;

    void Start()
    {
        floor = GetComponent<Rigidbody2D>();
        gameControl = Object.FindObjectOfType<GameControl>();
    }

    void Update()
    {
        floorSpeed = gameControl.backgroundSpeed;
        floor.velocity = new Vector2(floorSpeed, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}

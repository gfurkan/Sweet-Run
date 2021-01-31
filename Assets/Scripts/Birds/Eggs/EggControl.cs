using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{
    Rigidbody2D rb;
    GameControl gameControl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();
    }

    void Update()
    {
        IncreaseSize();
        transform.Rotate(new Vector3(0, 0, 5));
        rb.velocity = new Vector2(gameControl.backgroundSpeed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Shield" || col.gameObject.tag == "Character")
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
    void IncreaseSize()
    {
        if (gameObject.transform.localScale.x <= 0.05)
        {
            gameObject.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
        }
    }
}
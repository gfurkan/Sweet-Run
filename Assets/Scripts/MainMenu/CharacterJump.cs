using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public Sprite[] jumpAnimations;

    float waitingTime = 0;
    bool jumpControl = true;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {

        JumpAnimation();

    }
    void Update()
    {
        if (jumpControl)
        {
            spriteRenderer.sprite = jumpAnimations[2];
            waitingTime += Time.deltaTime;
            if (waitingTime > 0.2f)
            {
                rb.AddForce(new Vector2(0, 200));
                jumpControl = false;
                waitingTime = 0;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        jumpControl = true;
    }
    void JumpAnimation()
    {
        if (rb.velocity.y > 0)
        {
            spriteRenderer.sprite = jumpAnimations[1];
        }
        if (rb.velocity.y < 0)
        {
            spriteRenderer.sprite = jumpAnimations[0];
        }
    }
}


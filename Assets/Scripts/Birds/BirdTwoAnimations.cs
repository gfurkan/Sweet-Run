using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTwoAnimations : MonoBehaviour
{
    public Sprite[] birdTwo;

    int birdAnimationCounter = 0;

    float birdAnimationTime = 0;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        birdAnimationTime += Time.deltaTime;
        if (birdAnimationTime > 0.1f)
        {
            BirdAnimation();
            birdAnimationTime = 0;
        }
    }

    void BirdAnimation()
    {
        spriteRenderer.sprite = birdTwo[birdAnimationCounter++];
        if (birdAnimationCounter == birdTwo.Length)
        {
            birdAnimationCounter = 0;
        }

    }
}

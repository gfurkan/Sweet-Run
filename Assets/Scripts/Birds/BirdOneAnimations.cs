using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdOneAnimations : MonoBehaviour
{
    public Sprite[] birdOne;

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
        spriteRenderer.sprite = birdOne[birdAnimationCounter++];
        if (birdAnimationCounter == birdOne.Length)
        {
            birdAnimationCounter = 0;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdThreeAnimations : MonoBehaviour
{
    public Sprite[] birdThree;

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
        spriteRenderer.sprite = birdThree[birdAnimationCounter++];
        if (birdAnimationCounter == birdThree.Length)
        {
            birdAnimationCounter = 0;
        }

    }
}
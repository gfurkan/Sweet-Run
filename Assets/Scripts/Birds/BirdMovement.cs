using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public GameObject Egg1;
    public GameObject Egg2;
    public GameObject Egg3;
    public GameObject Egg4;
    public GameObject Egg5;
    public GameObject Egg6;

    Rigidbody2D Bird;
    GameControl gameControl;

    float birdSpeed = 0;
    double createEggTime = 0;
    double createEggPeriod = 2.5f;

    void Start()
    {
        Bird = GetComponent<Rigidbody2D>();
        gameControl = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();
    }
    void Update()
    {
        createEggTime = (double)Random.Range(1.0f, 3.0f);

        createEggPeriod += Time.deltaTime;
        if (createEggPeriod >= createEggTime)
        {
            CreateEgg();
            createEggPeriod = 0;
        }
        birdSpeed = gameControl.backgroundSpeed;
        Bird.velocity = new Vector2(birdSpeed, 0);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }

    }
    void CreateEgg()
    {
        Vector3 eggVec = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y - 0.5f));
        int eggType = Random.Range(1, 7);
        if (eggType == 1)
        {
            Instantiate(Egg1, eggVec, Quaternion.identity);
        }
        if (eggType == 2)
        {
            Instantiate(Egg2, eggVec, Quaternion.identity);
        }
        if (eggType == 3)
        {
            Instantiate(Egg3, eggVec, Quaternion.identity);
        }
        if (eggType == 4)
        {
            Instantiate(Egg4, eggVec, Quaternion.identity);
        }
        if (eggType == 5)
        {
            Instantiate(Egg5, eggVec, Quaternion.identity);
        }
        if (eggType == 6)
        {
            Instantiate(Egg6, eggVec, Quaternion.identity);
        }
    }
}
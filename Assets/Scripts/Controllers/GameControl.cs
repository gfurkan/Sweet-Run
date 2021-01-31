using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class GameControl : MonoBehaviour
{

    public GameObject bird1;
    public GameObject bird2;
    public GameObject bird3;

    public GameObject floorSingle;
    public GameObject floorMultiple;

    public GameObject backgroundOne;
    public GameObject backgroundTwo;

    [SerializeField]
    private GameObject panel;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb1, rb2, birdOne, floorS, floorM;
    CharacterControl characterControl;
    AudioSource audioSource;
    public AudioClip increaseSpeed;

    double speedChange;
    float length = 0;
    public float backgroundSpeed = -4.5f;
    float createBirdPeriod = 2;
    float createBirdTime = 3.6f;
    float createFloorPeriod = 2;
    float newDistance = 0;
    public float createFloorTime = 4.0f;


    int backgroundSpeedControl = 200;
    int birdCounter = 1;

    public int birdRandom;
    public bool birdCreated = false;

    bool birdDecreaseTime = true;
    bool floorDecreaseTime = true;

    private void Awake()
    {
        panel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);


    }
    void Start()
    {
        rb1 = backgroundOne.GetComponent<Rigidbody2D>();
        rb2 = backgroundTwo.GetComponent<Rigidbody2D>();
        length = backgroundOne.GetComponent<BoxCollider2D>().size.x;
        characterControl = Object.FindObjectOfType<CharacterControl>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        newDistance = Random.Range(-3f, 3f);
        if (panel.GetComponent<CanvasGroup>().alpha <= 0)
        {
            panel.SetActive(false);
        }

        createFloorPeriod += Time.deltaTime;
        if (createFloorPeriod > createFloorTime)
        {
            CreateFloor();
            createFloorPeriod = 0;
        }

        if (characterControl.score >= 600)
        {
            createBirdPeriod += Time.deltaTime;
            if (createBirdPeriod > createBirdTime)
            {

                CreateBird();
                birdCreated = true;
                createBirdPeriod = 0;
            }
        }


        BackgroundControl();


    }
    void CreateBird()
    {
        float yAxis = Random.Range(1.85f, 3.6f);
        Vector3 vec = new Vector3(15 + newDistance, yAxis);

        birdRandom = Random.Range(1, 4);
        if (birdRandom == 1)
        {

            var newBird = Instantiate(bird1, vec, Quaternion.identity);
            newBird.gameObject.name = "Bird " + birdCounter++;


        }
        if (birdRandom == 2)
        {

            var newBird = Instantiate(bird2, vec, Quaternion.identity);
            newBird.gameObject.name = "Bird " + birdCounter++;

        }
        if (birdRandom == 3)
        {

            var newBird = Instantiate(bird3, vec, Quaternion.identity);
            newBird.gameObject.name = "Bird " + birdCounter++;
        }

    }
    void BackgroundControl()
    {
        rb1.velocity = new Vector2(backgroundSpeed, 0);
        rb2.velocity = new Vector2(backgroundSpeed, 0);

        if (characterControl.score == backgroundSpeedControl)
        {
            backgroundSpeed += -1.5f;
            audioSource.PlayOneShot(increaseSpeed, 5);
            backgroundSpeedControl *= 2;

            if (birdDecreaseTime)
            {
                createBirdTime -= 0.6f;
            }
            if (createBirdTime == 1.2f)
            {

                birdDecreaseTime = false;
            }
            if (floorDecreaseTime)
            {
                createFloorTime -= 0.65f;
            }
            if (createFloorTime <= 1.4f)
            {
                floorDecreaseTime = false;
            }
        }

        if (backgroundOne.transform.position.x <= -length - 5)
        {
            backgroundOne.transform.position += new Vector3(length * 2, 0, 0);
        }
        if (backgroundTwo.transform.position.x <= -length - 5)
        {
            backgroundTwo.transform.position += new Vector3(length * 2, 0, 0);
        }
    }
    void CreateFloor()
    {
        Vector3 vecFloorS = new Vector3(15 + newDistance, -2.15f);
        Vector3 vecFloorM = new Vector3(15 + newDistance, 0.15f);
        int floorType = Random.Range(1, 4);

        if (floorType <= 2)
        {
            var newFloor = Instantiate(floorSingle, vecFloorS, Quaternion.identity);
        }
        if (floorType == 3)
        {
            var newFloor = Instantiate(floorMultiple, vecFloorM, Quaternion.identity);
        }

    }

}
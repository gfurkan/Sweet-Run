using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CharacterControl : MonoBehaviour
{
    public Image Life1;
    public Image Life2;
    public Image Life3;

    public Text scoreText;

    AudioSource audioSource;
    public AudioClip jump;
    public AudioClip birdHit;
    public AudioClip eggHit;
    public AudioClip shieldVoice;
    public AudioClip death;

    [SerializeField]
    private GameObject panel;

    public Sprite[] jumpAnimations;
    public Sprite[] walkAnimations;

    GameObject shield;
    Shield control;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Vector3 vec;

    int walkAnimationCounter = 0;
    int jumpControl = 0;
    int jumpSpeed = 600;
    int increaseScoreControl = 200;
    int lifeCounter = 3;

    float bestScore = 0;
    public float score = 0;
    float increaseScoreTime = 0;
    float horizontal = 1;
    float walkAnimationTÝme = 0;
    float increaseScoreSpeed = 0.6f;
    float finishGame = 1;
    float backToMainMenu = 0;


    bool shieldControl = true;
    bool lifeControl = true;
    bool gameOver = false;


    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        shield = GameObject.FindGameObjectWithTag("Shield");
        control = shield.GetComponent<Shield>();
        scoreText.text = " " + (int)score;
    }


    void Update()
    {
        if (gameOver)
        {
            StartCoroutine("BackToMainMenu");
            finishGame -= Time.deltaTime;

            if (finishGame >= 0)
            {
                Time.timeScale = finishGame;
            }
        }
        rb.velocity = new Vector2(0, rb.velocity.y);

        if (score == increaseScoreControl && increaseScoreSpeed > 0.1f)
        {
            increaseScoreSpeed -= 0.1f;
            increaseScoreControl *= 2;
        }

        IncreaseScore();
        if (!lifeControl)
        {
            StartCoroutine("LifeControlTrue");
        }
    }
    void LateUpdate()
    {
        Animation();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        jumpControl = 0;
    }
    public void CharacterJump()
    {
        if (jumpControl < 2 && shieldControl)
        {
            rb.velocity = new Vector2(horizontal * 0, 0);
            audioSource.PlayOneShot(jump, 0.5f);
            rb.AddForce(new Vector2(0, jumpSpeed));
            jumpControl++;
        }
    }

    void Animation()
    {
        walkAnimationTÝme += Time.deltaTime;
        if (walkAnimationTÝme > 0.02f)
        {
            if (jumpControl == 0)
            {
                spriteRenderer.sprite = walkAnimations[walkAnimationCounter++];
            }
            if (walkAnimationCounter == walkAnimations.Length)
            {
                walkAnimationCounter = 0;
            }
            walkAnimationTÝme = 0;

            if (rb.velocity.y > 0)
            {
                spriteRenderer.sprite = jumpAnimations[0];
            }
            if (rb.velocity.y < 0)
            {
                spriteRenderer.sprite = jumpAnimations[1];
            }
        }
    }
    public void ShieldControl()
    {
        if (rb.velocity.y == 0)
        {
            if (shieldControl)
            {
                control.OpenShield();
                audioSource.PlayOneShot(shieldVoice);
                shieldControl = false;
            }
            else
            {
                control.CloseShield();
                audioSource.PlayOneShot(shieldVoice);
                shieldControl = true;
            }

        }
    }
    void IncreaseScore()
    {
        increaseScoreTime += Time.deltaTime / 2;
        if (increaseScoreTime > increaseScoreSpeed)
        {
            score += 10;
            scoreText.text = " " + score;
            increaseScoreTime = 0;

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Bird" || col.gameObject.tag == "Egg")
        {
            if (col.gameObject.tag == "Bird")
            {
                audioSource.PlayOneShot(birdHit, 0.15f);
            }
            else if (col.gameObject.tag == "Egg")
            {
                audioSource.PlayOneShot(eggHit);
            }
            if (lifeCounter == 3 && lifeControl)
            {
                col.gameObject.SetActive(false);
                if (shieldControl)
                {
                    Life3.gameObject.SetActive(false);
                    lifeCounter--;
                    lifeControl = false;
                }
            }


            if (lifeCounter == 2 && lifeControl)
            {
                col.gameObject.SetActive(false);
                if (shieldControl)
                {
                    Life2.gameObject.SetActive(false);
                    lifeCounter--;
                    lifeControl = false;
                }
            }

            if (lifeCounter == 1 && lifeControl)
            {
                col.gameObject.SetActive(false);
                if (shieldControl)
                {
                    Life1.gameObject.SetActive(false);
                    lifeCounter--;
                    audioSource.PlayOneShot(death);
                    lifeControl = false;
                    gameOver = true;

                }

            }

        }
        if (col.gameObject.tag == "CharacterDes")
        {
            Life3.gameObject.SetActive(false);
            Life2.gameObject.SetActive(false);
            Life1.gameObject.SetActive(false);
            audioSource.PlayOneShot(death);
            gameOver = true;
        }
    }
    IEnumerator LifeControlTrue()
    {
        yield return new WaitForSeconds(0.2f);
        lifeControl = true;
    }
    IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(0.75f);
        GameOver();
        Time.timeScale = 1;
        panel.SetActive(true);
        panel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");

    }
    void GameOver()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", (int)bestScore);
        }


    }
}


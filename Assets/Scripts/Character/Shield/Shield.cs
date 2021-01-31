using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shield : MonoBehaviour
{
    GameObject characterControl;
    CharacterControl control;
    SpriteRenderer spriteRenderer;

    bool shieldControl = false;
    bool closeShield = false;

    void Start()
    {
        characterControl = GameObject.FindGameObjectWithTag("Character");
        control = characterControl.GetComponent<CharacterControl>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Rotate(0, 0, 3f);

    }
    void LateUpdate()
    {
        ShieldSize();
    }
    public void OpenShield()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;

        shieldControl = true;
    }

    public void CloseShield()
    {
        shieldControl = false;
        if (closeShield)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            if (gameObject.transform.localScale.x <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
    void ShieldSize()
    {
        if (shieldControl)
        {
            if (gameObject.transform.localScale.x <= 0.5f)
            {
                gameObject.transform.localScale += new Vector3(2, 2, 2) * Time.deltaTime;
            }
        }
        if (!shieldControl)
        {
            if (gameObject.transform.localScale.x >= 0.0f)
            {
                gameObject.transform.localScale += new Vector3(-2, -2, -2) * Time.deltaTime;
            }
            if (gameObject.transform.localScale.x <= 0)
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            closeShield = true;
        }
    }
}


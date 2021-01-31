using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private GameObject bestScoreTextControl;
    [SerializeField]
    private GameObject panel;
    AudioSource audioSource;

    bool scaleControl;
    bool startButton = false;

    private void Awake()
    {
        panel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    void Start()
    {

        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    void Update()
    {
        if (scaleControl)
        {
            bestScoreTextControl.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
        }
        if (!scaleControl)
        {
            bestScoreTextControl.transform.localScale += new Vector3(-0.005f, -0.005f, -0.005f);
        }
        if (bestScoreTextControl.transform.localScale.x >= 2.15f)
        {
            scaleControl = false;
        }
        if (bestScoreTextControl.transform.localScale.x <= 1.85f)
        {
            scaleControl = true;
        }

        if (panel.GetComponent<CanvasGroup>().alpha <= 0)
        {
            panel.SetActive(false);
        }
        if (panel.GetComponent<CanvasGroup>().alpha >= 1 && startButton)
        {
            SceneManager.LoadScene("level1");
        }

    }
    public void ChooseButton(int buttonNo)
    {
        if (buttonNo == 1)
        {
            startButton = true;
            panel.SetActive(true);
            panel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

        }
        if (buttonNo == 2)
        {
            Application.Quit();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ManagerScene: MonoBehaviour
{
    Scene scene;

    [Header("Button")]
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject exitButton;

    [Header("End Value")]
    [SerializeField] int endValue=1;

    [Header("Time")]
    [SerializeField] float fadeTime = 0.8f;
    [SerializeField] float delayTime = 0.5f;




    private void Awake()
    {
        scene = SceneManager.GetActiveScene();

        FadeOut();
    }

    void FadeOut()
    {
        startButton.GetComponent<CanvasGroup>().DOFade(endValue, fadeTime);
        exitButton.GetComponent<CanvasGroup>().DOFade(endValue, 0.8f).SetDelay(delayTime);
    }
    

    public void StartScene()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void ExitScene()
    {
        Application.Quit();
    }

   
}

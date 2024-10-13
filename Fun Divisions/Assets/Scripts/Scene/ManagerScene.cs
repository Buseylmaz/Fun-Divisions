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


    private void Awake()
    {
        scene = SceneManager.GetActiveScene();

        FadeOut();
    }

    void FadeOut()
    {
        startButton.GetComponent<CanvasGroup>().DOFade(1, 0.8F);
        exitButton.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
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

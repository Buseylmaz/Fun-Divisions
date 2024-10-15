using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSceneManager : MonoBehaviour
{
    Scene scene;

    

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }


    public void RepeatScene()
    {
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene(scene.buildIndex - 1);
    }

}

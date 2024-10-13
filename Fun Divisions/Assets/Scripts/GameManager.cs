using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    GameObject[] squaresArray = new GameObject[24];

    [SerializeField] GameObject squarePrefabs;

    [SerializeField] Transform squaresPanel;

    [Header("End Value")]
    [SerializeField] int endValue = 1;

    [Header("Time")]
    [SerializeField] float fadeTime = 0.2f;
    [SerializeField] float delayTime = 0.07f;

    private void Start()
    {
        CreateSquares();
    }

    public void CreateSquares()
    {
        for (int i = 0; i < squaresArray.Length; i++)
        {
            GameObject squares = Instantiate(squarePrefabs, squaresPanel);
            squaresArray[i] = squares;
        }

        StartCoroutine(DoFadeRoutine());
    }

    IEnumerator DoFadeRoutine()
    {
        foreach (var squares_ in squaresArray)
        {
            squares_.GetComponent<CanvasGroup>().DOFade(endValue,fadeTime);

            yield return new WaitForSeconds(delayTime);
        }
    }

}

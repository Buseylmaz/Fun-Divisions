using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject squarePrefabs;

    [Header("Transform")]
    [SerializeField] Transform squaresPanel;
    [SerializeField] Transform questionsPanel;

    [Header("End Value")]
    [SerializeField] int endValue = 1;


    [Header("Time")]
    [SerializeField] float fadeTime = 0.2f;
    [SerializeField] float delayTime = 0.07f;

    [Header("Text")]
    [SerializeField] Text questionsText;


    GameObject[] squaresArray = new GameObject[25];
    List<int> sectionValuesList = new List<int>();

    int dividedNumber, divisorNumber;
    int questionIndex;
    int buttonValue;
    int correctResult;

    bool isButtonPass;


    private void Start()
    {
        isButtonPass = false;

        questionsPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        
        CreateSquares();
    }

    public void CreateSquares()
    {
        for (int i = 0; i < squaresArray.Length; i++)
        {
            GameObject squares = Instantiate(squarePrefabs, squaresPanel);
            squares.GetComponent<Button>().onClick.AddListener(() => ButtonPass());
            squaresArray[i] = squares;
        }

        SectionValuesText();
        StartCoroutine(DoFadeRoutine());
    }

    void ButtonPass()
    {
        if (isButtonPass)
        {
            buttonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            Debug.Log(buttonValue);

            CheckTheResult();
        }
    }

    void CheckTheResult()
    {
        if (buttonValue == correctResult)
        {
            Debug.Log("TRUE");
        }
        else
        {
            Debug.Log("False");
        }
    }

    IEnumerator DoFadeRoutine()
    {
        foreach (var squares_ in squaresArray)
        {
            squares_.GetComponent<CanvasGroup>().DOFade(endValue,fadeTime);

            yield return new WaitForSeconds(delayTime);
        }

        Invoke("QuestionPanelOpen",0.5f);
    }


    void SectionValuesText()//Karelerin icinde ki texte 1-13 arasinda sayý yazdirma
    {
        foreach (var square in squaresArray)
        {
            int randomValue = Random.Range(1, 13);

            sectionValuesList.Add(randomValue);

            square.transform.GetChild(0).GetComponent<Text>().text = randomValue.ToString();
        }

        //Debug.Log(sectionValuesList[0]);
    }

    void QuestionPanelOpen()
    {
        AskQuestions();
        isButtonPass = true;
        questionsPanel.GetComponent<RectTransform>().DOScale(endValue, delayTime).SetEase(Ease.OutBack);
    }


    void AskQuestions()
    {
        divisorNumber = Random.Range(2, 11);

        questionIndex = Random.Range(0, sectionValuesList.Count);
        //Debug.Log(questionIndex);

        correctResult = sectionValuesList[questionIndex];

        dividedNumber = divisorNumber * correctResult;

        questionsText.text = dividedNumber.ToString() + " : " + divisorNumber.ToString();
    }
}

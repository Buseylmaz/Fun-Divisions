using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject squarePrefabs;
    [SerializeField] GameObject finalPanel;
    GameObject[] squaresArray = new GameObject[25];
    GameObject currentSquare;

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

    [Header("Sprites")]
    [SerializeField] Sprite[] sprite_;

    [SerializeField] AudioSource audioSource;
    public AudioClip buttonClip;


    
    List<int> sectionValuesList = new List<int>();

    int dividedNumber, divisorNumber;
    int questionIndex;
    int buttonValue;
    int correctResult;
    int heart_ = 3;


    bool isButtonPass;

    string difficultyLevelProblem;

    HeartManager heartManager;
    ScoreManager scoreManager;


    private void Start()
    {
        heartManager = Object.FindObjectOfType<HeartManager>(); //scripte ulasma
        heartManager.CheckHeart(heart_);

        scoreManager=Object.FindObjectOfType<ScoreManager>();

        finalPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        isButtonPass = false;

        questionsPanel.GetComponent<RectTransform>().localScale = Vector3.zero;




        audioSource = GetComponent<AudioSource>();

        CreateSquares();



    }

    public void CreateSquares()
    {
        for (int i = 0; i < squaresArray.Length; i++)
        {
            GameObject squares = Instantiate(squarePrefabs, squaresPanel);

            squares.transform.GetChild(1).GetComponent<Image>().sprite = sprite_[Random.Range( 0, sprite_.Length)];
            squares.GetComponent<Button>().onClick.AddListener(() => ButtonPass());
            squaresArray[i] = squares;
        }

        StartCoroutine(DoFadeRoutine());
        SectionValuesText();
        Invoke("QuestionPanelOpen", 2.3f);
    }

    void ButtonPass()
    {
        if (isButtonPass)
        {
            audioSource.PlayOneShot(buttonClip);

            buttonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);

            currentSquare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            CheckTheResult();
        }
    }

    void CheckTheResult()
    {
        if (buttonValue == correctResult)
        {
            currentSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            currentSquare.transform.GetChild(0).GetComponent<Text>().text = " ";
            currentSquare.transform.GetComponent<Button>().interactable = false; //butona basilamaz oyuncak cikinca

            scoreManager.IncreaseScore(difficultyLevelProblem);

            sectionValuesList.RemoveAt(questionIndex);

            if (sectionValuesList.Count > 0)
            {
                QuestionPanelOpen();
            }
            else
            {
                FinishGame();
            } 
        }
        else 
        {
            heart_--;
            heartManager.CheckHeart(heart_);
        }


        if (heart_ <= 0)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        isButtonPass = false;
        finalPanel.GetComponent<RectTransform>().DOScale(endValue, fadeTime).SetEase(Ease.OutBack);
    }

    IEnumerator DoFadeRoutine()
    {
        foreach (var squares in squaresArray)
        {
            squares.GetComponent<CanvasGroup>().DOFade(endValue, fadeTime);

            yield return new WaitForSeconds(delayTime);

        }
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



        if (dividedNumber<=40)
        {
            difficultyLevelProblem = "easy";
        }
        else if (dividedNumber > 40 && dividedNumber<=80)
        {
            difficultyLevelProblem = "medium";
        }
        else
        {
            difficultyLevelProblem = "difficulty";
        }



        questionsText.text = dividedNumber.ToString() + " : " + divisorNumber.ToString();
    }
}

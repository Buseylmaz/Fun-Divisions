using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int totalScore = 0;
    int increaseScore;


    [SerializeField] Text scoreText;


    private void Start()
    {
        scoreText.text = totalScore.ToString();
    }

    public void IncreaseScore(string difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case "easy":
                totalScore += 5;
                break;
            case "medium":
                totalScore += 10;
                break;
            case "difficulty":
                totalScore += 20;
                break;
        }

        totalScore += increaseScore;

        scoreText.text = totalScore.ToString();
    }
}

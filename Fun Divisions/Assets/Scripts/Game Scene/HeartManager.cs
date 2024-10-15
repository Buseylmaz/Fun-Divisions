using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{

    [SerializeField] GameObject[] heartImg;
    


    public void CheckHeart(int heart)
    {
        switch (heart)
        {
            case 3:
                heartImg[0].SetActive(true);
                heartImg[1].SetActive(true);
                heartImg[2].SetActive(true);
                break;
            case 2:
                heartImg[0].SetActive(true);
                heartImg[1].SetActive(true);
                heartImg[2].SetActive(false);
                break;
            case 1:
                heartImg[0].SetActive(true);
                heartImg[1].SetActive(false);
                heartImg[2].SetActive(false);
                break;
            case 0:
                heartImg[0].SetActive(false);
                heartImg[1].SetActive(false);
                heartImg[2].SetActive(false);
                break;
        }
    }
}

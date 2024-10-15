using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlphaPanelManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject alphaPanel;

    [Header("End Value")]
    [SerializeField] int endValue = 0;

    [Header("Time")]
    [SerializeField] float fadeTime = 2.5f;



    private void Start()
    {
        alphaPanel.GetComponent<CanvasGroup>().DOFade(endValue, fadeTime);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreObserver : MonoBehaviour
{
    public TextMeshProUGUI Scoretext;
    private int FinalScore;
    void Start()
    {
        Scoretext = GetComponent<TextMeshProUGUI>();
    }


    private void OnEnable()
    {
        Arrow.OnScoreUpdated += scorechange;
    }

    private void OnDisable()
    {
        Arrow.OnScoreUpdated -= scorechange;
    }

    private void scorechange(int score)
    {
        FinalScore += score;
        Scoretext.SetText("{0}", FinalScore);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;
    private const int incorrectWordScore = -10;
    private const int correctWordScore = 100;

    private void Start()
    {
        scoreText.text = "0";
    }

    public void correctWordScoreUpdate()
    {
        scoreText.text = (int.Parse(scoreText.text) + correctWordScore).ToString();
    }
    public void incorrectWordScoreUpdate()
    {
        scoreText.text = (int.Parse(scoreText.text) + incorrectWordScore).ToString();
    }



}

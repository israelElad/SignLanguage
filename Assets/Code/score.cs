using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;

    public static int scoreVal = 0;
    private const int incorrectWordScore = -10;
    private const int correctWordScore = 100;

    private void Start()
    {
        scoreText.text = scoreVal.ToString();
    }

    public void correctWordScoreUpdate()
    {

        scoreVal += correctWordScore;
        scoreText.text = scoreVal.ToString();
        PlayerPrefs.SetInt("HighScore", scoreVal);
        PlayerPrefs.Save();
    }
    public void incorrectWordScoreUpdate()
    {
        scoreVal += incorrectWordScore;
        scoreText.text = scoreVal.ToString();
    }
}

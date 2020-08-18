using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.scoreVal.ToString();
        highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        showCorrectWord();
        Invoke("loadMenuScene", 9.2f);
    }

    private void showCorrectWord()
    {
        string correctWord = PlayerPrefs.GetString("LastCorrect", "?").ToString();
        correctWord = correctWord.Replace('\n', ' '); //combine the lines
        correctWord = String.Join(" ", correctWord.Split(' ').Reverse());
        GameObject.Find("CorrectWord").GetComponent<Text>().text = correctWord + " :התייה הנוכנה הלימה ";
    }

    void loadMenuScene()
    {
        GameManager.resetGame();
        SceneManager.LoadScene("menuScene");
    }

}

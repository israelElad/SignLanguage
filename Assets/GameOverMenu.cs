using System.Collections;
using System.Collections.Generic;
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
        highscoreText.text= PlayerPrefs.GetInt("HighScore", -1).ToString(); //todo: change to 0
        Invoke("loadMenuScene", 5f);
    }

    void loadMenuScene()
    {
        GameManager.resetGame();
        SceneManager.LoadScene("menuScene");
    }







    // Update is called once per frame
    void Update()
    {
        
    }
}

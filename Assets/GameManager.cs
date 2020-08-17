using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class GameManager
{
    private const float INIT_WORD_DELAY = 1.7f;
    private const float INIT_FALL_SPEED = 2f;
    private const int INIT_LEVEL_NUM = 1;
    private const float INIT_CUP_SPEED = 10;
    private const int INIT_HEART_AMOUNT = 4;

    private static int heartAmount = INIT_HEART_AMOUNT;

    public static int LevelNum { get; set; } = INIT_LEVEL_NUM;
    public static float FallSpeed { get; set; } = INIT_FALL_SPEED;
    public static float WordDelay { get; set; } = INIT_WORD_DELAY;
    public static float CupSpeed { get; set; } = INIT_CUP_SPEED;
    public static int HeartAmount {
        get => heartAmount;
        set {
            if (value <= 0)
                gameOver();
            else
                heartAmount = value;
        }
    }


    public static void gameOver()
    {

        SceneManager.LoadScene("gameOverScene");

    }

    public static void resetGame()
    {
        WordDelay = INIT_WORD_DELAY;
        FallSpeed = INIT_FALL_SPEED;
        CupSpeed = INIT_CUP_SPEED;
        HeartAmount = INIT_HEART_AMOUNT;
        LevelNum = INIT_LEVEL_NUM;
        score.scoreVal = 0;
        //SceneManager.LoadScene("menuScene");
    }

    public static void nextLevel()
    {
        WordDelay = INIT_WORD_DELAY - (0.05f * LevelNum);
        LevelNum++;
        FallSpeed += 0.5f;
        CupSpeed += 1;
        SceneManager.LoadScene("gameScene");
    }


}

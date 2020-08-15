using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    private const float INIT_WORD_DELAY = 1.7f;

    public static int LevelNum { get; set; } = 1;
    public static float FallSpeed { get; set; } = 2f;
    public static float WordDelay { get; set; } = INIT_WORD_DELAY;
    public static float CupSpeed { get; set; } = 10;
    public static int HeartAmount { get; set; } = 4;




    public static void nextLevel()
    {
        WordDelay = INIT_WORD_DELAY - (0.05f * LevelNum);
        LevelNum++;
        FallSpeed += 0.5f;
        CupSpeed += 1;
        SceneManager.LoadScene("gameScene");
    }


}

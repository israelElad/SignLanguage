using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{

    public static int LevelNum { get; set; } = 1;
    public static float FallSpeed { get; set; } = 2f;
    public static float WordDelay { get; set; } = 1.7f;
    public static float CupSpeed { get; set; } = 10;
    public static int HeartAmount { get; set; } = 4;




    public static void nextLevel()
    {
        LevelNum++;
        FallSpeed += 0.5f;
        WordDelay -= 0.05f;
        CupSpeed += 1;
        SceneManager.LoadScene("gameScene");
    }


}

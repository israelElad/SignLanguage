using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{

    public static int LevelNum { get; set; } = 1;
    

    public static void nextLevel()
    {
        LevelNum++;
        SceneManager.LoadScene("gameScene");
    }


}

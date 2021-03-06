﻿using UnityEngine;
using UnityEngine.UI;

public class wordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    public wordDisplay SpawnWord()
    {
        Vector3 randomPos = new Vector3(Random.Range(-15f, 15f), 30f);
        // Instantiate an instance of a word prefab at a random position without rotation and set its parent to be the canvas so that it will show.
        GameObject wordObj = Instantiate(wordPrefab, randomPos, Quaternion.identity, wordCanvas);
        wordDisplay display = wordObj.GetComponent<wordDisplay>();
        Font f = Resources.Load<Font>("Fonts/Abraham-Regular");
        display.GetComponent<Text>().font = f;
        return display;
    }
}

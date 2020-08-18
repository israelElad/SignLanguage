﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YoutubePlayer;

public class wordManager : MonoBehaviour
{
    [SerializeField]
    List<string> wordslist;
    public wordSpawner spawner;
    int curWordIndex = 0;
    string correctWord;
    public LoadingIndicator isLoading;
    public bool doneLoading = false;
    public int TextObjInGame;
    // Start is called before the first frame update
    void Start()
    {
        doneLoading = false;
        DontDestroyOnLoad(GameObject.Find("Audio"));
        if (!GameObject.Find("Audio").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("Audio").GetComponent<AudioSource>().Play();
        }
        var loading = GameObject.Find("Loading");
        isLoading = loading.GetComponent("LoadingIndicator") as LoadingIndicator;
        GameObject.Find("Video Player").GetComponent<YoutubePlayer.YoutubePlayer>().YoutubeVideoStarting += Loaded;
        myDB db = GameObject.Find("Scripts").GetComponent<myDB>();
        wordslist = db.WordLottery();
        correctWord = wordslist[0];
        PlayerPrefs.SetString("LastCorrect", correctWord);
        PlayerPrefs.Save();
        Debug.Log("correctWord is: " + correctWord);
        wordslist.AddRange(wordslist.Take(6)); //add correct word again for better chance at winning, and also 5 wrong duplicates to prevent cheesing
        shuffleList(wordslist);
        TextObjInGame = wordslist.Count;
    }

    private void Loaded(string url)
    {
        isLoading.Loaded();
        doneLoading = true;
    }

    private void shuffleList(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public bool addNextWordFromList()
    {
        //shouldn't happen
        if (!wordslist.Any())
        {
            Debug.Log("wordsList is empty");
            return false;
        }

        //no more words
        if (curWordIndex >= wordslist.Count)
        {
            return false;
        }
        AddWord(wordslist[curWordIndex]);
        curWordIndex++;
        return true;
    }

    void AddWord(string word)
    {
        wordDisplay display = spawner.SpawnWord();
        Debug.Log(word);
        display.SetWord(word);
    }

    public string getCorrectWord()
    {
        return correctWord;
    }

    public List<string> getWordslist()
    {
        return wordslist;
    }

}

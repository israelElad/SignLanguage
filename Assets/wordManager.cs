using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YoutubePlayer;

public class wordManager : MonoBehaviour
{
    [SerializeField]
    List<string> wordslist;
    public wordSpawner spawner;
    int curWordIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        myDB db=GameObject.Find("Scripts").GetComponent<myDB>();
        wordslist = db.WordLottery();
    }

    public bool addNextWordFromList()
    {
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
        return wordslist[0];
    }

    //todo: implement for levels where there is more than 1 correct word! 
    //List<string> getCurrectWords()
    //{

    //}

}

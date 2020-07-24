using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YoutubePlayer;

public class wordManager : MonoBehaviour
{
    [SerializeField]
    List<string> wordslist;
    public wordSpawner spawner;
    int curWordIndex=0;
    string correctWord;
    // Start is called before the first frame update
    void Start()
    {
        myDB db=GameObject.Find("Scripts").GetComponent<myDB>();
        wordslist = db.WordLottery();
        correctWord = wordslist[0];
        Debug.Log("correctWord is: " + correctWord);
        shuffleList(wordslist);
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
        if (!wordslist.Any())
        {
            Debug.Log("wordsList is empty");
            return false;
        }

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

    //todo: implement for levels where there is more than 1 correct word! 
    //List<string> getCurrectWords()
    //{

    //}

}

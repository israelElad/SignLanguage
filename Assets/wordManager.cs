using System;
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
    int curWordIndex=0;
    string correctWord;
    public int TextObjInGame;
    // Start is called before the first frame update
    void Start()
    {
        myDB db=GameObject.Find("Scripts").GetComponent<myDB>();
        wordslist = db.WordLottery();
        //loadingScreen();
        correctWord = wordslist[0];
        Debug.Log("correctWord is: " + correctWord);
        shuffleList(wordslist);
        TextObjInGame = wordslist.Count;
    }

    public GameObject loadingWordPrefab;

    //private void loadingScreen() 
    //{
    //    GameObject go = (GameObject)Instantiate(loadingWordPrefab);

        
    //}

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

    public List<string> getWordslist()   {
        return wordslist;
    }

}

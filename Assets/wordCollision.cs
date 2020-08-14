using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class wordCollision : MonoBehaviour
{
    private wordManager manager;
    public score scoreClass;
    private heartsSystem hs;
    private bool hasCollide = false;


    public void Start()
    {
        GameObject scriptObj = GameObject.Find("Scripts");
        manager = scriptObj.GetComponent("wordManager") as wordManager;
        GameObject scoreObj = GameObject.Find("Score");
        scoreClass = scoreObj.GetComponent("score") as score;
        GameObject heartsObj = GameObject.Find("Hearts");
        hs = heartsObj.GetComponent("heartsSystem") as heartsSystem;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(hasCollide == true){
            return;
        }
        hasCollide=true;
        if (other.gameObject.tag == "Cup")
        {
            Text textInCup = gameObject.GetComponent<Text>();

            Debug.Log("current word: " + textInCup.text + " correct word is:" + manager.getCorrectWord());

            if (textInCup.text == manager.getCorrectWord())
            {
                Debug.Log("correct word!");
                scoreClass.correctWordScoreUpdate();
                GameManager.HeartAmount += 1;
                GameManager.nextLevel();
            }
            else
            {
                Debug.Log("incorrect word!");
                scoreClass.incorrectWordScoreUpdate();
                GameManager.HeartAmount -= 1;
                hs.removeHeart();
                if (manager.TextObjInGame == 0)
                {
                    Debug.Log("No more words to catch- next level");
                    GameManager.nextLevel();
                }
            }

            Destroy(gameObject);
            manager.TextObjInGame--;
            Debug.Log(manager.TextObjInGame);
        }
        else if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            manager.TextObjInGame--;
            Debug.Log("floor!");
            Debug.Log(manager.TextObjInGame);
            if (manager.TextObjInGame == 0)
            {
                Debug.Log("No more words to catch- next level");
                GameManager.nextLevel();
            }
        }

        
            
    }
}

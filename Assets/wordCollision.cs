using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class wordCollision : MonoBehaviour
{
    private wordManager manager;
    public score scoreClass;

    public void Start()
    {
        GameObject scriptObj = GameObject.Find("Scripts");
        manager = scriptObj.GetComponent("wordManager") as wordManager;
        GameObject scoreObj = GameObject.Find("Score");
        scoreClass = scoreObj.GetComponent("score") as score;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision with" + other);
        if (other.gameObject.tag == "Cup")
        {
            Text textInCup = gameObject.GetComponent<Text>();
            
            Debug.Log("current word: " + textInCup.text + " correct word is:" + manager.getCorrectWord());

            if (textInCup.text == manager.getCorrectWord())
            {
                Debug.Log("correct word!");
                scoreClass.correctWordScoreUpdate();
            }
            else
            {
                Debug.Log("incorrect word!");
                scoreClass.incorrectWordScoreUpdate();
            }
        }
        Destroy(gameObject);
    }
}

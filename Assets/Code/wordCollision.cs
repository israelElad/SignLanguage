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
                DontDestroyOnLoad(GameObject.Find("success sound"));
                DontDestroyOnLoad(GameObject.Find("Particle System"));
                DontDestroyOnLoad(GameObject.Find("Particle System (1)"));
                //Destroy(gameObject);
                GameManager.nextLevel();
                AudioSource audioData = GameObject.Find("success sound").GetComponent<AudioSource>();
                audioData.PlayOneShot(audioData.clip);
                GameObject.Find("Particle System").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Particle System (1)").GetComponent<ParticleSystem>().Play();
            }
            else
            {
                Debug.Log("incorrect word!");
                scoreClass.incorrectWordScoreUpdate();
                GameManager.HeartAmount -= 1;
                hs.removeHeart();

                AudioSource audioData = GameObject.Find("Wrong sound").GetComponent<AudioSource>();
                audioData.PlayOneShot(audioData.clip);

                if (manager.TextObjInGame <= 1)
                {
                    GameObject.Find("CorrectWord").GetComponent<Text>().text = manager.getCorrectWord() + ":התייה הנוכנה הלימה ";
                    Debug.Log("No more words to catch- next level");
                    Invoke("nextLevelCall", 5f);
                }
                else
                {
                    Destroy(gameObject);
                }
            }

        }
        else if (other.gameObject.tag == "Floor")
        {
            
            Debug.Log("floor!");
            if (manager.TextObjInGame <= 1)
            {
                GameObject.Find("CorrectWord").GetComponent<Text>().text = manager.getCorrectWord() + ":התייה הנוכנה הלימה ";
                Debug.Log("No more words to catch- next level");
                DontDestroyOnLoad(GameObject.Find("Wrong sound"));
                AudioSource audioData = GameObject.Find("Wrong sound").GetComponent<AudioSource>();
                audioData.PlayOneShot(audioData.clip);
                Invoke("nextLevelCall", 5f);
                GameManager.HeartAmount -= 1;
            }
            else {
                Destroy(gameObject);
            }

        }

           
    }

    void nextLevelCall()
    {
        Debug.Log("next level mannn");
        GameManager.nextLevel();
    }

    void OnDestroy()
    {
        manager.TextObjInGame--;
        Debug.Log(gameObject.GetComponent<Text>().text);
    }
}



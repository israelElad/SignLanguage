using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wordCollision : MonoBehaviour
{
  private wordManager manager;

    public void Start()
    {
        GameObject scriptObj = GameObject.Find("Scripts");
        manager = scriptObj.GetComponent("wordManager") as wordManager;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision with" + other);
        if (other.gameObject.tag == "Cup")
        {
            Text textInCup = gameObject.GetComponent<Text>();
            //todo: add manager! drag and drop?!
            if (textInCup.text == manager.getCorrectWord())
            {
                Debug.Log("correct word!");
            }
            else
            {
                Debug.Log("incorrect word!");
            }
        }
        Destroy(gameObject);
    }
}

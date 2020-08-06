using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordTimer : MonoBehaviour
{
    public wordManager manager;
    private float nextWordTime = 0;

    public void Update()
    {
        // next word should appear now
        if (Time.time >= nextWordTime)
        {
            //add next word
            if (manager.addNextWordFromList() ==false)
            {
                Debug.Log("no more words to display!");
            }
            nextWordTime = Time.time + GameManager.WordDelay;
            GameManager.WordDelay *= 0.99f;
        }
    }

}

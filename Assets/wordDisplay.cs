using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class wordDisplay : MonoBehaviour
{
    
    public Text text;
    public float fallSpeed=1f;

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void removeWord()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}

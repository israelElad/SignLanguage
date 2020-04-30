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
        text.text = Reverse(word);
    }

    public static string Reverse(string s)
    {
        s= new String(s.Select(x => x == '(' ? ')' : (x == ')' ? '(' : x)).ToArray());
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
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

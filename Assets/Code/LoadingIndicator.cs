using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingIndicator : MonoBehaviour
{
    public Text isLoading;
    // Start is called before the first frame update
    void Start()
    {
        isLoading.text = "...ןעוט";
        if (GameManager.LevelNum > 1 && GameManager.WasSuccess)
        {
            GameObject.Find("WellDone").GetComponent<Text>().text = "!דובכה לכ";
        }
    }

    public void Loaded()
    {
        isLoading.text = "";
        GameObject.Find("WellDone").GetComponent<Text>().text = "";
    }
}

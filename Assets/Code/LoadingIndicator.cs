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
    }

    public void Loaded()
    {
        isLoading.text = "";
    }
}

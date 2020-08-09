using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}

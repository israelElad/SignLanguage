using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * GameManager.CupSpeed, 0f, 0f);
    }
}

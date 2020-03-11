using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllable : MonoBehaviour
{
    private const float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, 0f);
    }
}

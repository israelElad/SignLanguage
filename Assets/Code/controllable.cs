using UnityEngine;

public class controllable : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * GameManager.CupSpeed, 0f, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    public wordDisplay SpawnWord()
    {
        Vector3 randomPos = new Vector3(Random.Range(-20f, 20f), 30f);
        // Instantiate an instance of a word prefab at a random position without rotation and set its parent to be the canvas so that it will show.
        GameObject wordObj = Instantiate(wordPrefab, randomPos, Quaternion.identity, wordCanvas);
        //does it have the component?
        wordDisplay display=wordObj.GetComponent<wordDisplay>();
        return display;
    }
}

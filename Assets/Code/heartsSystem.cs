using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartsSystem : MonoBehaviour
{

    [SerializeField] private Sprite heartSprite;
    private static List<Image> heartsList;
    private static Vector2 heartsNextPos;

    private void Start()
    {
        heartsList = new List<Image>();
        heartsNextPos = new Vector2(-611, 263);
        for (int i = 0; i < GameManager.HeartAmount; i++)
        {
            addHeart();
        }
        
    }

    //creates a heart
    private void CreateHeartImage(Vector2 anchoredPosition)
    {
        GameObject heartGameObj = new GameObject("Heart", typeof(Image));
        //set the heart game object to be a child of this transform
        heartGameObj.transform.SetParent(transform);
        heartGameObj.transform.localPosition = Vector3.zero;

        //Locate and Size heart
        heartGameObj.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObj.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);

        //set heart sprite
        Image heartImage = heartGameObj.GetComponent<Image>();
        heartImage.sprite = heartSprite;

        heartsList.Add(heartImage);
    }

    List<Image> getHeartsList()
    {
        return heartsList;
    }

    public void removeHeart()
    {
        //if heartsList.Count==0 GameManager will call gameOver function 
        if (heartsList.Count > 0)
        {
            Debug.Log("Removed heart!");
            Destroy(heartsList[heartsList.Count - 1]);
            heartsList.RemoveAt(heartsList.Count - 1);
            heartsNextPos -= new Vector2(30, 0);
        }
    }

    public void addHeart()
    {
        Debug.Log("added heart!");
        CreateHeartImage(heartsNextPos);
        heartsNextPos += new Vector2(30, 0);

    }

}

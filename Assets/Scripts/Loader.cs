using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class Loader : MonoBehaviour
{
    public static Loader instance { get; private set; }
    public Sprite[] backgrounds;
    public Sprite[] icons;
    public GameObject cardPrefab;
    public PlayerList playerList;
    public Transform cardContainer;
    int i = 0;

    void Awake()
{
    if (instance == null)
    {
        instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
}
    // Start is called before the first frame update
    void Start()
    {
        TextAsset data = Resources.Load<TextAsset>("players");
        playerList = JsonUtility.FromJson<PlayerList>(data.text);
        foreach (player p in playerList.players)
        {
            GameObject cardObject = Instantiate(cardPrefab, cardContainer);
            cardObject.GetComponent<card>().InitializeCardData(p, i);
            i++;
        }
    }

    // Update is called once per frame
    public void Initialize()
    {
        
    }
}
[System.Serializable]
public class player
{
    public string name;
    public int level;
    public string id;
    public int igindex;
}
[System.Serializable]
public class PlayerList
{
    public player[] players;
}

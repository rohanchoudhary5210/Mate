using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


public class Loader : MonoBehaviour
{
    public static Loader instance { get; private set; }
    public Sprite[] backgrounds;
    public Sprite[] icons;
    public GameObject cardPrefab;
    [SerializeField]
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

        Initialize();
       
    }
    public void LoadPlayerData(string jsonString, int bgindex)
    {
        Debug.Log("Loading player data: " + jsonString);
        TextAsset data = Resources.Load<TextAsset>("NewJson");
        JObject originalData = JObject.Parse(data.text);
        Debug.Log("Original JSON: " + originalData.ToString());
        JObject changeddata = JObject.Parse(jsonString);
        Debug.Log("Changed JSON: " + changeddata.ToString());

        originalData[bgindex] = changeddata;
        string updatedJsonString = JsonConvert.SerializeObject(originalData, Formatting.Indented);
        Debug.Log("Updated JSON: " + updatedJsonString);

        File.WriteAllText(Application.persistentDataPath + "/NewJson.json", updatedJsonString);
        Debug.Log("Data saved to: " + Application.persistentDataPath + "/NewJson.json");

    }

    // Update is called once per frame
    public void Initialize()
    {
        TextAsset data = Resources.Load<TextAsset>("NewJson");
        playerList = JsonConvert.DeserializeObject<PlayerList>(data.text);
        Debug.Log("playerlist loaded" + playerList);
        foreach (player p in playerList.players)
        {
            GameObject cardObject = Instantiate(cardPrefab, cardContainer);
            cardObject.GetComponent<card>().InitializeCardData(p, i);
            i++;
        }
    }
}
[SerializeField]
public class player
{
    public string name;
    public string id;
    public int level;
    public int igindex;
    public Dictionary<string, int> details;
}
[System.Serializable]
public class PlayerList
{
    public player[] players;
}

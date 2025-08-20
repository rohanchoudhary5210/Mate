using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Specialized;


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
    public void LoadPlayerData(string jsonString, int igindex)
    {
        TextAsset data = Resources.Load<TextAsset>("NewJson");
        JArray originalData = JArray.Parse(data.text);
        JObject playerData = JObject.Parse(jsonString);
        Debug.Log(jsonString);
        originalData[igindex] = playerData;

        string updatedJsonString = JsonConvert.SerializeObject(originalData, Formatting.Indented);
        Debug.Log("Updated JSON: " + updatedJsonString);
        File.WriteAllText("D:/Co/C/Assets/Resources/NewJson.json", updatedJsonString);
        Debug.Log("Data saved to: D:/Co/C/Assets/Resources/NewJson.json");

        // Debug.Log("Loading player data: " + jsonString);
        // TextAsset data = Resources.Load<TextAsset>("NewJson");
        // 
        // Debug.Log("Original JSON: " + originalData.ToString());
        // JArray changeddata = JArray.Parse(jsonString);
        // Debug.Log("Changed JSON: " + changeddata.ToString());

        // int xv=(int)changeddata[0]["details"]["X value"];
        // Debug.Log("X value: " + xv);
        // int yv=(int)changeddata[0]["details"]["Y value"];
        // Debug.Log("Y value: " + yv);
        // string updatedJsonString = JsonConvert.SerializeObject(originalData, Formatting.Indented);
        // Debug.Log("Updated JSON String: " + updatedJsonString);
        // int X=(int)originalData["players"][igindex]["details"]["X value"];
        // int Y=(int)originalData["players"][igindex]["details"]["Y value"];
        // X = xv;
        // Debug.Log("Updated X value: " + X);
        // Y = yv;
        // Debug.Log("Updated Y value: " + Y);

        // 
        // Debug.Log("Data saved to: " + Application.persistentDataPath + "/NewJson.json");

    }
    // public void changeData(player value)
    // {
    //     TextAsset data = Resources.Load<TextAsset>("NewJson");
    //     JObject originalData = JObject.Parse(data.text);
    //     string playerX=(string)
    // }

    // Update is called once per frame
    public void Initialize()
    {
        TextAsset data = Resources.Load<TextAsset>("NewJson");
        JArray originalData = JArray.Parse(data.text);
        //playerList = JsonConvert.DeserializeObject<PlayerList>(originalData.ToString());
        Debug.Log("playerlist loaded" + originalData);
        foreach (player p in originalData.ToObject<List<player>>())
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

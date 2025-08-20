using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor;

public class card : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI details;
    [SerializeField] private Button button;


    // bgindex is passed as an argument, so it's a local parameter
    public void InitializeCardData(player data, int bgindex)
    {
        nameText.text = data.name;
        idText.text = data.id;
        levelText.text = data.level.ToString();
        iconImage.sprite = Loader.instance.icons[data.igindex];
        backgroundImage.sprite = Loader.instance.backgrounds[bgindex];
        if (button.onClick != null)
        {
            button.onClick.AddListener(() => { work(data, bgindex); });

            
        }
    }

    public void work(player data, int bgindex)
    {
        data.details["X value"] = data.level;
        data.details["Y value"] = bgindex;
        details.text = $"X: {data.details["X value"]}, Y: {data.details["Y value"]}";
        string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
        Loader.instance.LoadPlayerData(jsonString,bgindex);
        // Debug.Log("Serialized player data: " + jsonString);
        // Debug.Log(jsonString);
        // string filePath = Application.persistentDataPath + "D:/Co/C/Assets/Resources/NewJson.json";
        // File.WriteAllText(filePath, jsonString);
    }
}
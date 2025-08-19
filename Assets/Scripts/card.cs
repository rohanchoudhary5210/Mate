using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image backgroundImage;

    // bgindex is passed as an argument, so it's a local parameter
    public void InitializeCardData(player data, int bgindex)
    {
        nameText.text = data.name;
        idText.text = data.id;
        levelText.text = data.level.ToString();
        iconImage.sprite = Loader.instance.icons[data.igindex];
        backgroundImage.sprite = Loader.instance.backgrounds[bgindex];
    }
}
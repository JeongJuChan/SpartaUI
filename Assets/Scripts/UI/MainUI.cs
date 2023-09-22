using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [Header("Name Setting")]
    [SerializeField] private Button nameSettingButton;
    [SerializeField] private GameObject nameSettingPanel;

    [Header("Main Choice UI")]
    [SerializeField] private GameObject mainChoicePanel;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private GameObject statusPanel;
    [SerializeField] private GameObject inventoryPanel;

    [Header("Character Info")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TextMeshProUGUI fillText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI goldText;
    private CharacterData _characterData;

    private void OnEnable()
    {
        nameSettingButton.onClick.AddListener(OnClickNameSettingButton);
        statusButton.onClick.AddListener(OnClickStatusButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    private void Start()
    {
        _characterData = CharacterStat.instance.characterData;
        UpdateCharacterInfo();
    }

    private void OnDisable()
    {
        nameSettingButton.onClick.RemoveAllListeners();
        statusButton.onClick.RemoveAllListeners();
        inventoryButton.onClick.RemoveAllListeners();
    }

    public void UpdateCharacterInfo()
    {
        levelText.text = _characterData.level.ToString();
        expSlider.value = _characterData.exp / 12; // 임시 -> 구현한다면 exp 테이블에서 가져올 듯
        fillText.text = $"{_characterData.exp} / 12";
        goldText.text = _characterData.gold.ToString("0,###");
    }

    public void UpdateCharacterName(string newName)
    {
        nameText.text = newName;
        descriptionText.text = $"{newName}{_characterData.description}" ;
    }

    private void OnClickNameSettingButton()
    {
        nameSettingPanel.SetActive(true);
        nameSettingButton.gameObject.SetActive(false);
    }

    private void OnClickInventoryButton()
    {
        inventoryPanel.SetActive(true);
        mainChoicePanel.SetActive(false);
    }

    private void OnClickStatusButton()
    {
        statusPanel.SetActive(true);
        mainChoicePanel.SetActive(false);
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UsePanel : MonoBehaviour
{
    [Header("Item Use")]
    [SerializeField] private TextMeshProUGUI useTitleText;
    [SerializeField] private TextMeshProUGUI useQuestionText;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button confirmButton;

    [Header("Selected Item Info")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [Header("Stat Info Texts")]
    [SerializeField] private TextMeshProUGUI attackInfoText;
    [SerializeField] private TextMeshProUGUI shieldInfoText;
    [SerializeField] private TextMeshProUGUI healthInfoText;
    [SerializeField] private TextMeshProUGUI criticalInfoText;

    public event Action OnUsed;

    private void OnEnable()
    {
        cancelButton.onClick.AddListener(ClosePanel);
        confirmButton.onClick.AddListener(UseItem);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        cancelButton.onClick.RemoveAllListeners();
        confirmButton.onClick.RemoveAllListeners();
    }

    public void SetCurrentItemData(ItemData itemData)
    {
        SetItemInfo(itemData);
        SetItemUsingTexts(itemData);
    }

    private void SetItemInfo(ItemData itemData)
    {
        itemImage.sprite = itemData.icon;
        itemName.text = itemData.displayName;
        itemDescription.text = itemData.description;
        attackInfoText.text = itemData.attack.ToString();
        shieldInfoText.text = itemData.defense.ToString();
        healthInfoText.text = itemData.health.ToString();
        criticalInfoText.text = itemData.critical.ToString();
    }

    private void SetItemUsingTexts(ItemData itemData)
    {
        switch (itemData.type)
        {
            case ItemType.Equipment:
                useTitleText.text = "Equip";
                useQuestionText.text = itemData.isEquipped ? 
                    $"{itemData.displayName}을(를) 장착 해제 하시겠습니까?" : 
                    $"{itemData.displayName}을(를) 장착 하시겠습니까?";
                break;
            case ItemType.Consumable:
                useTitleText.text = "Consume";
                useQuestionText.text = $"{itemData.displayName}을(를) 사용 하시겠습니까?";
                break;
        }
    }

    private void UseItem()
    {
        OnUsed?.Invoke();
        
        ClosePanel();
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    
}

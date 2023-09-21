using System;
using System.Collections;
using System.Collections.Generic;
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
        SetItemUsingTexts(itemData);
    }

    private void SetItemUsingTexts(ItemData itemData)
    {
        switch (itemData.type)
        {
            case ItemType.Equipment:
                useTitleText.text = "Equip";
                useQuestionText.text = itemData.isEquipped ? 
                    $"{itemData.name}��(��) ���� ���� �Ͻðڽ��ϱ�?" : 
                    $"{itemData.name}��(��) ���� �Ͻðڽ��ϱ�?";
                break;
            case ItemType.Consumable:
                useTitleText.text = "Consume";
                useQuestionText.text = $"{itemData.name}��(��) ��� �Ͻðڽ��ϱ�?";
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

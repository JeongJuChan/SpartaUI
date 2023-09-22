using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("InventoryUI ScrollView")]
    [SerializeField] private ScrollRect inventoryScrollView;

    [Header("Back Button")]
    [SerializeField] private Button inventoryBackButton;

    [Header("Main ChoiceUI")]
    [SerializeField] private GameObject mainChoicePanel;

    // 과제 막바지 와서 느낀 점 : 팝업 UI 매니저 필수.. -> 언제 생기고 사라질지 모르는 UI들이 너무 많음 (참조가 풀릴 가능성 다수)
    [Header("StatusUI")]
    [SerializeField] private StatusUI statusUI;

    [Header("ItemUI Size")]
    private float itemSize;
    private float itemSpace;
    private float _totalItemSize;

    [Header("InventoryUI Content")]
    [SerializeField] private RectTransform _inventoryRectTramsform;
    [SerializeField] private int initRowSize = 4;
    [SerializeField] private int initColumnSize = 4;
    private GridLayoutGroup _gridLayoutGroup;

    [Header("Item Management")]
    [SerializeField] private GameObject itemUIPrefab;
    [SerializeField] private UsePanel usePanel;
    [SerializeField] private TextMeshProUGUI inventoryCountText;
    private GameObject[] itemFrameArr;
    private List<ItemUI> _itemUIs = new List<ItemUI>();
    private int _currentIdx;

    [Header("Init Items")]
    [SerializeField] private Item[] items;

    [Header("Selected ItemUI")]
    private ItemUI _selectedItemUI;

    private void Awake()
    {
        _gridLayoutGroup = _inventoryRectTramsform.GetComponent<GridLayoutGroup>();
    }

    private void OnEnable()
    {
        inventoryBackButton.onClick.AddListener(OnClickBackButton);
    }

    void Start()
    {
        itemSize = _gridLayoutGroup.cellSize.y;
        itemSpace = _gridLayoutGroup.spacing.y;

        itemFrameArr = new GameObject[_inventoryRectTramsform.childCount];
        InitItemArr();
        InitContentSize();

        gameObject.SetActive(false);

        InitItems();
    }

    private void OnDisable()
    {
        inventoryBackButton.onClick.RemoveAllListeners();
    }

    private void OnDestroy()
    {
        foreach (var itemUI in _inventoryRectTramsform.GetComponentsInChildren<ItemUI>())
        {
            itemUI.OnItemClicked -= ActiveUsePopup;
        }
    }
    
    private void UpdateInventoryCount()
    {
        inventoryCountText.text = $"{_itemUIs.Count} / {itemFrameArr.Length}";  
    }

    private void OnClickBackButton()
    {
        mainChoicePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void InitItems()
    {
        foreach (var item in items)
        {
            ItemUI itemUI = Instantiate(itemUIPrefab, itemFrameArr[_currentIdx].transform).GetComponent<ItemUI>();
            itemUI.SetData(item.itemData);
            itemUI.OnItemClicked += ActiveUsePopup;
            _itemUIs.Add(itemUI);
            _currentIdx++;
        }

        UpdateInventoryCount();
        usePanel.OnUsed += OnUsedItem;
    }

    private void ActiveUsePopup(bool isActive, ItemUI itemUI)
    {
        ItemData tempData = itemUI.Data;
        ItemData newData = InitNewData(tempData);

        itemUI.SetData(newData);
        _selectedItemUI = itemUI;
        usePanel.SetCurrentItemData(itemUI.Data);
        usePanel.gameObject.SetActive(isActive);
    }

    private ItemData InitNewData(ItemData tempData)
    {
        ItemData itemData = new ItemData();
        itemData.displayName = tempData.displayName;
        itemData.description = tempData.description;
        itemData.type = tempData.type;
        itemData.isEquipped = tempData.isEquipped;
        itemData.attack = tempData.attack;
        itemData.health = tempData.health;
        itemData.defense = tempData.defense;
        itemData.critical = tempData.critical;
        itemData.icon = tempData.icon;
        itemData.equipPrefab = tempData.equipPrefab;
        return itemData;
    }

    private void OnUsedItem()
    {
        switch (_selectedItemUI.Data.type)
        {
            case ItemType.Equipment:
                _selectedItemUI.Equip(!_selectedItemUI.Data.isEquipped);
                _selectedItemUI.Data.isEquipped = !_selectedItemUI.Data.isEquipped;
                break;
            case ItemType.Consumable:
                _selectedItemUI.Consume();
                break;
        }

        statusUI.UpdateUI(_selectedItemUI.Data);

        _selectedItemUI = null;
    }

    private void InitItemArr()
    {
        int i = 0;

        foreach (RectTransform trans in _inventoryRectTramsform)
        {
            itemFrameArr[i] = trans.gameObject;
            i++;
        }
    }

    private void InitContentSize()
    {
        _totalItemSize = itemSpace + itemSize;
        float initYSize = (itemFrameArr.Length / initRowSize - initColumnSize) * _totalItemSize;
        Vector2 sizeDelta = _inventoryRectTramsform.sizeDelta;
        sizeDelta.y = initYSize;
        _inventoryRectTramsform.sizeDelta = sizeDelta;
    }
}

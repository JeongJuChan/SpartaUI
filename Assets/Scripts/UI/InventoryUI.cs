using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("InventoryUI ScrollView")]
    [SerializeField] private ScrollRect inventoryScrollView;

    [Header("Back Button")]
    [SerializeField] private Button inventoryBackButton;

    [Header("Main Choice UI")]
    [SerializeField] private GameObject mainChoicePanel;

    [Header("ItemUI Size")]
    [SerializeField] private float itemSize;
    [SerializeField] private float itemSpace;
    private float _totalItemSize;

    [Header("InventoryUI Content")]
    [SerializeField] private RectTransform _inventoryRectTramsform;
    [SerializeField] private int initRowSize = 4;
    [SerializeField] private int initColumnSize = 4;
    private GridLayoutGroup _gridLayoutGroup;

    [Header("Item Management")]
    [SerializeField] private GameObject itemUIPrefab;
    private GameObject[] itemFrameArr;
    private int _currentIdx;
    

    [Header("Init Items")]
    [SerializeField] private Item[] items;
    [SerializeField] private GameObject itemPopupUI;
    

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
            //itemUI.
            //item.ItemData
        }
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

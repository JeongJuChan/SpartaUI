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
    private GameObject[] itemArr;
    private int _currentIdx;

    private void Awake()
    {
        _gridLayoutGroup = _inventoryRectTramsform.GetComponent<GridLayoutGroup>();
    }

    void Start()
    {
        itemSize = _gridLayoutGroup.cellSize.y;
        itemSpace = _gridLayoutGroup.spacing.y;

        itemArr = new GameObject[_inventoryRectTramsform.childCount];
        InitItemArr();
        InitContentSize();
    }

    
    private void InitItemArr()
    {
        int i = 0;

        foreach (RectTransform trans in _inventoryRectTramsform)
        {
            itemArr[i] = trans.gameObject;
            i++;
        }
    }

    private void InitContentSize()
    {
        _totalItemSize = itemSpace + itemSize;
        float initYSize = (itemArr.Length / initRowSize - initColumnSize) * _totalItemSize;
        Vector2 sizeDelta = _inventoryRectTramsform.sizeDelta;
        sizeDelta.y = initYSize;
        _inventoryRectTramsform.sizeDelta = sizeDelta;
    }
}

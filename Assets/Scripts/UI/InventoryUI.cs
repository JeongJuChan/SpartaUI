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

    [Header("InventoryUI Content")]
    [SerializeField] private RectTransform _inventoryRectTramsform;
    [SerializeField] private int initRowSize = 4;
    [SerializeField] private int initColumnSize = 4;
    private GridLayoutGroup _gridLayoutGroup;
    private float preYPos;


    [Header("Item Active Management")]
    private GameObject[] itemArr;

    private void Awake()
    {
        _gridLayoutGroup = _inventoryRectTramsform.GetComponent<GridLayoutGroup>();
    }

    private void OnEnable()
    {
        inventoryScrollView.onValueChanged.AddListener(OnScrollMoved);
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
        Vector2 sizeDelta = _inventoryRectTramsform.sizeDelta;
        sizeDelta.y = (itemSpace + itemSize) * ((itemArr.Length / initRowSize) - initColumnSize);
        _inventoryRectTramsform.sizeDelta = sizeDelta;
    }

    private void OnDisable()
    {
        inventoryScrollView.onValueChanged.RemoveAllListeners();
    }
    private void OnScrollMoved(Vector2 newPos)
    {
        if (preYPos < newPos.y)
        {

        }
        else if (preYPos >  newPos.y)
        {

        }
    }

}

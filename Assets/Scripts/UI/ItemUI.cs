using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [field : SerializeField]
    public Image Icon { get; private set; }
    [field : SerializeField]
    public ItemData ItemData { get; private set; }

    [Header("Interaction")]
    [SerializeField] private Button itemClickButton;
    [SerializeField] private GameObject equipmentPanel;


    // InventoryUI의 InitItem에서 event로 꺼고 켜기 넘기는 방법 vs 게임 오브젝트 참조로 한 번 받아서 여기서 처리하는 방법
    public event Action<bool> OnItemClicked;


    private void OnEnable()
    {
        itemClickButton.onClick.AddListener(OnClickItem);
    }

    private void OnDisable()
    {
        itemClickButton.onClick.RemoveAllListeners();
    }

    

    private void OnClickItem()
    {
        //OnItemClicked?.Invoke();
    }
}

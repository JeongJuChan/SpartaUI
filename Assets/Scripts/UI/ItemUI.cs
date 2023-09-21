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


    // InventoryUI�� InitItem���� event�� ���� �ѱ� �ѱ�� ��� vs ���� ������Ʈ ������ �� �� �޾Ƽ� ���⼭ ó���ϴ� ���
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

using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image Icon { get; private set; }
    public ItemData Data { get; private set; }

    [Header("Interaction")]
    [SerializeField] private Button itemClickButton;
    [SerializeField] private GameObject equipBackgroundImage;

    public event Action<bool, ItemUI> OnItemClicked;

    private void Awake()
    {
        Icon = GetComponent<Image>();
    }

    private void OnEnable()
    {
        itemClickButton.onClick.AddListener(OnClickItem);
    }

    private void OnDisable()
    {
        itemClickButton.onClick.RemoveAllListeners();
    }

    public void SetData(ItemData itemData)
    {
        Data = itemData;
        SetItemInfo();
    }

    public void Consume()
    {

    }

    public void Equip(bool isActive)
    {
        equipBackgroundImage.SetActive(isActive);
    }

    private void SetItemInfo()
    {
        if (Icon == null)
            Icon = GetComponent<Image>();

        Icon.sprite = Data.icon;
    }

    private void OnClickItem()
    {
        OnItemClicked?.Invoke(true, this);
    }

    
}

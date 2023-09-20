using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [Header("Name Setting")]
    [SerializeField] private Button nameSettingButton;
    [SerializeField] private GameObject nameSettingPanel;

    [Header("Gold")]
    [SerializeField] private TextMeshProUGUI goldText;

    [Header("Main Choice UI")]
    [SerializeField] private GameObject mainChoicePanel;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;


    private void OnEnable()
    {
        nameSettingButton.onClick.AddListener(OnClickNameSettingButton);
        statusButton.onClick.AddListener(OnClickStatusButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    

    private void OnDisable()
    {
        nameSettingButton.onClick.RemoveAllListeners();
        statusButton.onClick.RemoveAllListeners();
        inventoryButton.onClick.RemoveAllListeners();
    }

    private void OnClickNameSettingButton()
    {
        nameSettingPanel.SetActive(true);
        nameSettingButton.gameObject.SetActive(false);
    }

    private void OnClickInventoryButton()
    {

        mainChoicePanel.SetActive(false);
    }

    private void OnClickStatusButton()
    {

        mainChoicePanel.SetActive(false);
    }
}

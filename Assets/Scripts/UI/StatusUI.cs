using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [Header("Status Texts")]
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI shieldText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;

    [Header("Back Button")]
    [SerializeField] private Button statusBackButton;

    [Header("Main Choice UI")]
    [SerializeField] private GameObject mainChoicePanel;

    private void OnEnable()
    {
        statusBackButton.onClick.AddListener(OnClickBackButton);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        statusBackButton.onClick.RemoveAllListeners();
    }

    private void OnClickBackButton()
    {
        mainChoicePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void UpdateUI()
    {

    }
}

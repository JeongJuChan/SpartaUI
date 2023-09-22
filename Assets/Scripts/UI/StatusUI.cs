using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Animation;
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

    private CharacterData characterData;

    private void OnEnable()
    {
        statusBackButton.onClick.AddListener(OnClickBackButton);
    }

    private void Start()
    {
        characterData = CharacterStat.instance.characterData;
        UpdateUI(characterData);
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

    public void UpdateUI(ItemData itemData)
    {
        attackText.text = GetStatText(characterData.attack, itemData.attack);
        shieldText.text = GetStatText(characterData.defense, itemData.defense);
        healthText.text = GetStatText(characterData.health, itemData.health);
        criticalText.text = GetStatText(characterData.critical, itemData.critical);
    }

    private string GetStatText(float characterStat, float itemStat)
    {
        string statText = itemStat == 0f ?
            $"{characterStat + itemStat}":
            $"{characterStat + itemStat} ({characterStat} + <color=green>{itemStat}</color>)";

        return statText;
    }

    public void UpdateUI(CharacterData characterData)
    {
        attackText.text = characterData.attack.ToString();
        shieldText.text = characterData.defense.ToString();
        healthText.text = characterData.health.ToString();
        criticalText.text = characterData.critical.ToString();
    }
}

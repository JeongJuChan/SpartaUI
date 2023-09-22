using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameSetting : MonoBehaviour
{
    [Header("Name Settings")]
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button changeNameButton;
    [SerializeField] private int nameMinLength = 2;
    [SerializeField] private int nameMaxLength = 8;
    [SerializeField] private MainUI mainUI;

    private void Start()
    {
        nameInputField.placeholder.GetComponent<TextMeshProUGUI>().text = $"ÀÌ¸§({nameMinLength}~{nameMaxLength}ÀÚ)";
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        nameInputField.onValueChanged.AddListener(OnNameChanged);
        confirmButton.onClick.AddListener(OnClickChangeNameBtn);
    }

    private void OnDisable()
    {
        nameInputField.onValueChanged.RemoveAllListeners();
        confirmButton.onClick.RemoveAllListeners();
    }

    private void OnNameChanged(string newName)
    {
        nameInputField.text = newName;
    }

    private void OnClickChangeNameBtn()
    {
        if (nameInputField.text.Length < nameMinLength || nameInputField.text.Length > nameMaxLength)
        {
            nameInputField.text = null;
            return;
        }

        mainUI.UpdateCharacterName(nameInputField.text);
        changeNameButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

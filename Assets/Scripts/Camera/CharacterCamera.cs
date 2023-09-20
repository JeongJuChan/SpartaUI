using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCamera : MonoBehaviour
{
    private Camera _characterCamera;
    [SerializeField] private Canvas characterCanvas;

    private void Awake()
    {
        _characterCamera = GetComponent<Camera>();    
    }

    private void Start()
    {
        CreateRT();
    }

    private void CreateRT()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.Default);

        rt.Create();
        _characterCamera.targetTexture = rt;

        RawImage raw = Instantiate(characterCanvas.gameObject).GetComponentInChildren<RawImage>();
        raw.texture = _characterCamera.targetTexture;
    }
}

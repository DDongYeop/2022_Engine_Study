using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour
{
    private UIDocument _document;
    private Camera _mainCamera;
    private VisualElement _potion;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        VisualElement root = _document.rootVisualElement;
        _potion = root.Q<VisualElement>("Potion");
        
        //여기서 메뉴플레이어가 나옴 
        
    }
}

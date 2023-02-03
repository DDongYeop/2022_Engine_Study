using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class TestDocument : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        VisualElement backGround = root.Q("Background");

        Button btn = root.Q<Button>("MyBtn");
        btn.RegisterCallback<ClickEvent>(e =>
        {
            // 버튼 눌렀을때 색상 변경 
            Random rand = new Random();
            backGround.style.backgroundColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
        });
    }
}

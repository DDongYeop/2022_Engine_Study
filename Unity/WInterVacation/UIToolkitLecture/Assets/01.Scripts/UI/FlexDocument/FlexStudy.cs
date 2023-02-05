using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlexStudy : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        Button toggleBtn = root.Q<Button>("BtnShow");
        
        toggleBtn.RegisterCallback<ClickEvent>(evt =>
        {
            // VisualElement card = root.Q<VisualElement>(className: "card"); //클래스 이름이 card인 걸 가져와 1개만
            List<VisualElement> cardList = root.Query<VisualElement>(className: "card").ToList(); //클래스 이름이 card인 걸 가져와 여러개를 
            // 한개만 가져올거면 Q를 쓰고 여러개 가져올일이 있다면 Quary을 쓴다. 

            cardList.ForEach(card =>
            {
                if (card != null && card.ClassListContains("on"))
                {
                    card?.RemoveFromClassList("on");
                    card.AddToClassList("off");
                }
                else
                {
                    card?.RemoveFromClassList("off");
                    card?.AddToClassList("on");
                }

            });

            // 덮어쓸떄 만약에 인라인으로 스타일이 지정되어있다면 절대 못 덮어쓴다. (변경해돈게 우선적) 
        });
    }
}

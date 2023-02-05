using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChatDialog : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _chatTemplate;
    [SerializeField] private Sprite _profileSprite;
    
    private VisualElement _root;
    private UIDocument _document;
    private int _showIndex;
    private List<VisualElement> _chatList;
    private ScrollView _scrollView;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _document.rootVisualElement;
        _showIndex = 0;
        _chatList = _root.Query<VisualElement>(className: "chat").ToList();
        _scrollView = _root.Q<ScrollView>("ScrollViewChat"); // 스크롤 뷰를 가져오고 
    }

    private void Update()
    {
        // 여기서 스페이스 누를 때마다 List에 showIndex번쨰 녀석에게 on을 붙여주고 //리스트에 더이상 아이템이 없다면 
        // 모든 녀석에게서 on을 때라 

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (_showIndex >= _chatList.Count)
        //         CLearListOn();
        //     else
        //     {
        //         _chatList[_showIndex].AddToClassList("on");
        //         _showIndex++;
        //         
        //     }
        // }

        if (Input.GetButtonDown("Jump"))
        {
            VisualElement chat = _chatTemplate.Instantiate();
            chat = chat.Q("ChatMsg");
            StartCoroutine(DelayCorutine(0.1f, () =>
            {
                chat.AddToClassList("on");
                _scrollView.verticalScroller.ScrollPageDown(1);
                // _scrollView.verticalScroller.value = _scrollView.verticalScroller.highValue;
            }));
            _scrollView.contentContainer.Add(chat);
        }
    }

    private IEnumerator DelayCorutine(float time, Action Callback)
    {
        yield return new WaitForSeconds(time);
        Callback();
    }

    private void CLearListOn()
    {
        _chatList.ForEach(x => x.RemoveFromClassList("on"));
        _showIndex = 0;
    }
}

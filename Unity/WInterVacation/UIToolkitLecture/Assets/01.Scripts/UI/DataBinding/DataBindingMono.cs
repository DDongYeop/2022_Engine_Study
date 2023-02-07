using System;
using System.Collections;
using System.Collections.Generic;
using DataBinding;
using UnityEngine;
using UnityEngine.UIElements;

public class DataBindingMono : MonoBehaviour
{
    private UIDocument _document;
    private TextField _nameInput;
    private TextField _infoInput;
    private VisualElement _content;

    [SerializeField] private VisualTreeAsset _cardTemplate;
    
    // PersonSO을 만들어서 SOList를 여기 넣어두면 해당 리스트에 있는 Person을 자동으로 카드로 만들어서 더해주는 거를 할거다
    // 애니메이션까지

    private Person _currentPerson = null;

    [SerializeField] private List<PeopleSO> _people;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement root = _document.rootVisualElement;
        _nameInput = root.Q<TextField>("NameInput");
        _infoInput = root.Q<TextField>("InfoInput");
        
        _nameInput.RegisterCallback<ChangeEvent<string>>(OnNameChanged);
        _infoInput.RegisterCallback<ChangeEvent<string>>(OnInfoChanged);

        _content = root.Q<VisualElement>("Content");
        
        //2명의 카드만 추가 
        _content.Clear(); //기존에 만들어진 카드 클리어  
        _people.ForEach(so =>
        {
            Person p = new Person(so.name, so.info, so.sprite);
            VisualElement cardXML = _cardTemplate.Instantiate().Q("CardBoarder");
            _content.Add(cardXML);
            
            Card c = new Card(cardXML, p);
            
            cardXML.RegisterCallback<ClickEvent>(evt =>
            {
                _currentPerson = p;
                _nameInput.SetValueWithoutNotify(p.Name); // 변경 이벤트를 방생 시키지 않고 값을 변경하는거 
                _infoInput.SetValueWithoutNotify(p.Info);
            });

            StartCoroutine(DelayCo(.01f, () =>
            {
                cardXML.AddToClassList("on");
            }));
        });
    }

    private IEnumerator DelayCo(float time, Action Callback)
    {
        yield return new WaitForSeconds(time);
        Callback();
    }

    private void OnNameChanged(ChangeEvent<string> evt)
    {
        if (_currentPerson == null)
            return;
        _currentPerson.Name = evt.newValue;
    }

    private void OnInfoChanged(ChangeEvent<string> evt)
    {
        if (_currentPerson == null)
            return;
        _currentPerson.Info = evt.newValue;
    }
}

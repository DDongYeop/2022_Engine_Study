using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataBinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DataBindingMono : MonoBehaviour
{
    private UIDocument _document;
    private TextField _nameInput;
    private TextField _infoInput;
    private VisualElement _content;
    private DropDownController _dropDownController;

    [SerializeField] private VisualTreeAsset _cardTemplate;
    
    // PersonSO을 만들어서 SOList를 여기 넣어두면 해당 리스트에 있는 Person을 자동으로 카드로 만들어서 더해주는 거를 할거다
    // 애니메이션까지

    private Person _currentPerson = null;

    [SerializeField] private List<PeopleSO> _people;
    private List<Card> _cardList = new List<Card>();

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

        // 드랍다운 
        #region DropDown
        // DropdownField spriteDrop = root.Q<DropdownField>("SpriteDropdown");
        // spriteDrop.choices = _people.Select(x => x.name).ToList();
        // spriteDrop.value = _people[0].name;
        #endregion
        _dropDownController = new DropDownController(root, _people);
        
        _content = root.Q<VisualElement>("Content");
        _content.RegisterCallback<ClickEvent>(evt =>
        {
            ClearSelect();
            _nameInput.SetValueWithoutNotify("");
            _infoInput.SetValueWithoutNotify("");
            _currentPerson = null;
        });
        
        //2명의 카드만 추가 
        _content.Clear(); //기존에 만들어진 카드 클리어  
        _people.ForEach(so => MakeCard(so));
        
        //여기에 버튼 눌럿을 때 선택값들을 이용해서 새로울 카드가 만들어져서 등장하게 해주고, 
        //단 입력값이 없을때는 Dubug.Log을 이용해서 입력을 하도록 해라. 메세지 띄우기 
        root.Q<Button>("CreateBtn").RegisterCallback<ClickEvent>(CreateBtnClick);
    }

    private void CreateBtnClick(ClickEvent evt)
    {
        if (_nameInput.value == "" || _infoInput.value == "")
        {
            Debug.Log("Error: 필수값을 입력하세요");
            return;
        }

        MakeCard(_nameInput.value, _infoInput.value, _dropDownController.SelectedValue.sprite);
    }

    private void MakeCard(PeopleSO so)
    {
        MakeCard(so.name, so.info, so.sprite);
    }

    private void MakeCard(string name, string info, Sprite profile)
    {
        Person p = new Person(name, info, profile);
        VisualElement cardXML = _cardTemplate.Instantiate().Q("CardBoarder");
        _content.Add(cardXML);
            
        Card c = new Card(cardXML, p);
        _cardList.Add(c);
            
        cardXML.RegisterCallback<ClickEvent>(evt =>
        {
            evt.StopPropagation();
            _currentPerson = p;
            _nameInput.SetValueWithoutNotify(p.Name); // 변경 이벤트를 방생 시키지 않고 값을 변경하는거 
            _infoInput.SetValueWithoutNotify(p.Info);
            ClearSelect();
            c.SelectVisuble(true);
        });

        StartCoroutine(DelayCo(.01f, () =>
        {
            cardXML.AddToClassList("on");
        }));
    }

    private void ClearSelect()
    {
        _cardList.ForEach(c => c.SelectVisuble(false));
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

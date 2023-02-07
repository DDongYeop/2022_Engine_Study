using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DropDownController
{
    public PeopleSO SelectedValue { get; private set; }

    private DropdownField _dropdown;

    public DropDownController (VisualElement root, List<PeopleSO> people)
    {
        _dropdown = root.Q<DropdownField>("SpriteDropdown");
        Debug.Log(_dropdown);
        _dropdown.choices = people.Select(x => x.name).ToList();
        _dropdown.value = people[0].name;
        SelectedValue = people[0];

        _dropdown.RegisterCallback<ChangeEvent<string>>(evt => SelectedValue = people.Find(x => x.name == evt.newValue));
        
        // RX 프로그래밍 
        // UniRX
    }
}

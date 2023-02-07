using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DataBinding
{
    public class Card
    {
        private VisualElement _cardRoot; // 이게 카드 xml의 루드가 되는 요소
        private Person _person;
        
        private Label _nameLabel;
        private Label _infoLabel;
        private VisualElement _profileImage;

        public Card(VisualElement cardRoot, Person person)
        {
            _cardRoot = cardRoot;
            _person = person;
            _nameLabel = _cardRoot.Q<Label>("NameLabel");
            _infoLabel = _cardRoot.Q<Label>("InfoLabel");
            _profileImage = _cardRoot.Q<VisualElement>("Image");

            _person.OnChanged += UpdateInfo;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            _nameLabel.text = _person.Name;
            _infoLabel.text = _person.Info;
            _profileImage.style.backgroundImage = new StyleBackground(_person.Sprite);
        }

        public void SelectVisuble(bool value)
        {
            if (value)
            {
                _cardRoot.AddToClassList("select");
            }
            else
            {
                _cardRoot.RemoveFromClassList("select");
            }
        }
    }
}

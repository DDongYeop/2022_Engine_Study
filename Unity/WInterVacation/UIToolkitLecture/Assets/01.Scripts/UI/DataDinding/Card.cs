using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DataBinding
{
    public class Card
    {
        private VisualElement _cardRoot; // 이게 카드 xml의 루드가 되는 요소

        private Label _nameLabel;
        private Label _infoLabel;
        private VisualElement _profileImage;

        public Card(VisualElement cardRoot)
        {
            
        }
    }
}

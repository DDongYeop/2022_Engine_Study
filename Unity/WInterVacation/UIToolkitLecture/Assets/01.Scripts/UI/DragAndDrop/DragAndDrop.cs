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
        _potion.AddManipulator(new Dragger(PotionDeop));
    }

    private void PotionDeop(Vector2 startPos, Vector2 endPos)
    {
        //드롭된 위치에 플레이어가 있는지 판단해서 있다면 해당 플레이어의 체력 업 
        Vector2 endScreenPos = new Vector2(endPos.x, Screen.height - endPos.y);
        
        Ray ray = _mainCamera.ScreenPointToRay(endScreenPos);
        RaycastHit hit;
        int playerLayer = LayerMask.NameToLayer("Player");

        bool isRayHit = Physics.Raycast(ray, out hit, _mainCamera.farClipPlane, 1 << playerLayer);

        if (isRayHit)
        {
            PlayerController p = hit.collider.GetComponent<PlayerController>();
            if (p != null)
            {
                _potion.parent.Remove(_potion); //VisualElement를 삭제할 때는 부모로부터 삭제하면 잘 된다. 
                                                //실제 삭제가 아니라 노드트리에서만 뺴는거다. 메모리에서 삭제되는거 아님. _potion은 여전히 잘 가르키고 있다
                p.ChangeHealth(20);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Dragger : MouseManipulator
{
    private Vector2 _startPos; //드래그 시작 위치
    private bool _isDragging = false;
    private Vector2 _originalPos; //원본 위치

    private Action<Vector2, Vector2> _dropCallback; //드랍되었을 때 실행할 콜백


    public Dragger(Action<Vector2, Vector2> DropCallback)
    {
        _dropCallback = DropCallback; // 드롭 콜백 넣어주고 
        _isDragging = false;
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
    }
    
    protected override void RegisterCallbacksOnTarget()
    {
        //타겟이 활성화되었을 때 달아줘야하는 콜백 이벤트
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        //타겟이 비활성화되었을 때 제거해야 하는 콜백이벤트들
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }
    
    // 이 이름은 정해진거 아님
    protected void OnMouseDown(MouseDownEvent evt)
    {
        if (CanStartManipulation(evt)) //지덩된 activator의 조건등을 만족하는 검사한다. 
        {
            _startPos = evt.localMousePosition;
            _originalPos = new Vector2(target.style.left.value.value, target.style.top.value.value);
            _isDragging = true;
            
            //여기에 뭔가 하나 더해야하는데 일단 안 하고 
            target.CaptureMouse(); //마우스를 잡겠다.
            evt.StopPropagation();
        }
    }
    
    protected void OnMouseMove(MouseMoveEvent evt)
    {
        if (_isDragging && target.HasMouseCapture())
        {
            Vector2 diff = evt.localMousePosition - _startPos; //이동거리가 측정된다(이번 이벤트 프레임간)

            target.style.top = new Length(target.layout.y + diff.y, LengthUnit.Pixel);
            target.style.left = new Length(target.layout.x + diff.x, LengthUnit.Pixel);
        }
    }
    
    protected void OnMouseUp(MouseUpEvent evt)
    {
        if (!_isDragging || !target.HasMouseCapture())
            return;
        
        target.ReleaseMouse(); //릴리즈해서 풀어주고
        _isDragging = false;
        _dropCallback?.Invoke(_originalPos, evt.mousePosition);
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;
using static Define;

public class AgentInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> OnPointerPostionChanged;

    public UnityEvent OnFireButtonPress;
    public UnityEvent OnFireButtonRelease;
    private bool _fireButtonDown = false;

    public UnityEvent OnreloadButtonPress;

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
        GetReloadInput();
    }

    private void GetReloadInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnreloadButtonPress?.Invoke();
        }
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (_fireButtonDown == false)
            {
                _fireButtonDown = true;
                OnFireButtonPress?.Invoke();
            }
        }
        else
        {
            if (_fireButtonDown == true)
            {
                _fireButtonDown = false;
                OnFireButtonRelease?.Invoke();
            }
        }
    }

    private void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector2 mouseInWordPos = MainCam.ScreenToWorldPoint(mousePos);
        OnPointerPostionChanged?.Invoke(mouseInWordPos);
    }

    private void GetMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        OnMovementKeyPress?.Invoke(new Vector2(x, y));
    }
}

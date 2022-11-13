using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int _maxHelth = 100;
    [SerializeField] private int _health;

    public int Health
    {
        get { return _health; }
        set 
        { 
            _health = value; 
            _onHealthChange?.Invoke((float) Health/_maxHelth);
        }
    }

    [SerializeField] private UnityEvent _onDead;
    [SerializeField] private UnityEvent<float> _onHealthChange;
    [SerializeField] private UnityEvent _onHit, _onHeal;

    private void Start() 
    {
        Health = _maxHelth;
    }

    public void OnHit(int damge)
    {
        Health -= damge;
        if (Health <= 0)
            _onDead?.Invoke();
        else 
            _onHit?.Invoke();
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, _maxHelth);
        _onHeal?.Invoke();
    }
}

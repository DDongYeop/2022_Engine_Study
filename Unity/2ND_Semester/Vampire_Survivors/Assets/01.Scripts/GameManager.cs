using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State { get; private set; }

    private readonly List<Icomponent> components = new (); 

    private void Awake() 
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start() 
    {
        components.Add(new UIComponent());
        components.Add(new PlayerComponent());

        components.Add(GetComponent<TileComponent>());
        components.Add(GetComponent<EnemyConpoment>());


        UpdateState(GameState.INIT);
    }

    public void UpdateState(GameState state)
    {
        foreach (var component in components)
        {
            component.UpdateState(state);
        }

        State = state;

        if (State == GameState.INIT)
            UpdateState(GameState.STANDBY);
    }

    public T GetGameComponent<T>() where T : class, Icomponent
    {
        var value = default(T);

        foreach (var component in components.OfType<T>())
        {
            value = component;
        }

        return value;
    }
}

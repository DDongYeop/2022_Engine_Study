using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Enemy 
{
    public Vector3 Position
    {
        set => gameObejct.transform.position = value;
        get => gameObejct.transform.position;
    }

    protected GameObject gameObejct;

    protected Subject<Enemy> enemyDestroyStream = new();

    public Enemy(GameObject gameObject)
    {
        this.gameObejct = gameObject;
    }

    public virtual void ReturnObject() { }

    public void DestroySubscribe(Action<Enemy> action)
    {
        enemyDestroyStream.Subscribe(action);   
    }

    public static class EnemyBuilder
    {
        public static Enemy Build(PoolObjectType type)
        {
            var gameObject = ObjectPool.Instance.GetObject(type);

            switch (type)
            {
                case PoolObjectType.Enemy:
                    return new Slime(gameObject);
                default:
                    return new Enemy(gameObject);
            }
        }
    }
}

using UnityEngine;

public abstract class IPlayerComponent : IComponent
{
    protected PlayerData playerData;
    protected GameObject player;

    public IPlayerComponent(GameObject player)
    {
        this.player = player;
    }

    public IPlayerComponent(GameObject player, PlayerData playerData){
        this.player = player;
        this.playerData = playerData;
    }

    public abstract void UpdateState(GameState state);
  
}
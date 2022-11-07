using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelected;

    public Turret Turret { get; set; }

    public void SetTurret(Turret turret)
    {
        this.Turret = turret;
    }

    public bool IsEmpty()
    {
        return this.Turret == null;
    }

    public void SelectTurret()
    {
        OnNodeSelected?.Invoke(this);
    }
}

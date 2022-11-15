using System;
using UnityEngine;

public class Node : IComparable<Node>
{
    public Vector3Int pos;
    public Node _parent;
    public float G;
    public float F;

    // F = G + H; G는 내가 지금까지 온 길,H는 내가 길은 모르는데 직선거리로 가면 이정도돼

    public int CompareTo(Node other)
    {
        if (other.F == this.F)
            return 0;
        // else if (other.F < this.F)
        //     return -1;
        // else
        //     return 1;
        else
            return other.F < this.F ? -1 : 1;
    }

    public bool Equals(Node p)
    {
        if (p is null)
            return false;
        if (this.GetType() != p.GetType())
            return false;
        
        return pos == p.pos;
    }

    public static bool operator == (Node lhs, Node rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
                return true;
            else
                return false;
        }

        return lhs.Equals(rhs);
    }

    public static bool operator != (Node lhs, Node rhs) => !(lhs == rhs);
}

using UnityEngine.Events;

public interface IAgent
{
    public int Heath { get; }
    public UnityEvent OnDie { get; set; }
    public UnityEvent OnGetHit { get; set; }
}

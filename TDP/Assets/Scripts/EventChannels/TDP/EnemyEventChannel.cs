using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/Enemy")]
public class EnemyEventChannel : EventChannelSO
{
    public UnityAction<EnemyController> OnEventRaised;

    public void RaiseEvent(EnemyController value)
    {
        OnEventRaised?.Invoke(value);
    }
}

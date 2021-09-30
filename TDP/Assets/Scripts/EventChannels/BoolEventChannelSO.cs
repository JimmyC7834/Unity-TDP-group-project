using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/Bool")]
public class BoolEventChannelSO : EventChannelSO
{
    public UnityAction<bool> OnEventRaised;

    public void RaiseEvent(bool value)
    {
        OnEventRaised?.Invoke(value);
    }
}

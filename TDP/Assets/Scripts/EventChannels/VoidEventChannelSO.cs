using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/Void")]
public class VoidEventChannelSO : EventChannelSO
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}

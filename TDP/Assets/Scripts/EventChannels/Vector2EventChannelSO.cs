using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/Vector2")]
public class Vector2EventChannelSO : EventChannelSO
{
    public UnityAction<Vector2> OnEventRaised;

    public void RaiseEvent(Vector2 value)
    {
        OnEventRaised?.Invoke(value);
    }
}

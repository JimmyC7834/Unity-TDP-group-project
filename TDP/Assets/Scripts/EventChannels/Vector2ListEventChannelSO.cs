using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/Vector2List")]
public class Vector2ListEventChannelSO : EventChannelSO
{
    public UnityAction<List<Vector2>> OnEventRaise;

    public void RaiseEvent(List<Vector2> value)
    {
        OnEventRaise?.Invoke(value);
    }
}

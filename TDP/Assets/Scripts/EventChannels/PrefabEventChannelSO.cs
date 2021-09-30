using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/Prefab")]
public class PrefabEventChannelSO : EventChannelSO
{
    public UnityAction<GameObject> OnEventRaised;

    public void RaiseEvent(GameObject value)
    {
        OnEventRaised?.Invoke(value);
    }
}

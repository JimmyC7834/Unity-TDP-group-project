using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/ResourceObject")]
public class ResourceObjectEventChannel : EventChannelSO
{
    public UnityAction<ResourceObject> OnEventRaised;

    public void RaiseEvent(ResourceObject value)
    {
        OnEventRaised?.Invoke(value);
    }
}

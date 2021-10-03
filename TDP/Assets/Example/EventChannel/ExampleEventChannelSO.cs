using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannel/Example")]
public class ExampleEventChannelSO : EventChannelSO
{
    public UnityAction<ExampleClass> OnEventRaised;

    public void RaiseEvent(ExampleClass value)
    {
        OnEventRaised?.Invoke(value);
    }
}

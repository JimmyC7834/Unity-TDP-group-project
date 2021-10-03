using UnityEngine;

public class ExampleSpawner : MonoBehaviour
{
    [SerializeField] private ExamplePool _pool;

    private void OnEnable()
    {
        _pool.SetParent(transform);
        _pool.Request();
        _pool.Request();
        _pool.Request();
    }

    private void OnDisable() {
        _pool.Return(GetComponentsInChildren<ExampleClass>());
    }
}

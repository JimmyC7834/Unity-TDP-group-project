using UnityEngine;

using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Factory/Example")]
public class ExampleFactorySO : FactorySO<ExampleClass>
{
    public override ExampleClass Create()
    {
        return new GameObject("Example").AddComponent<ExampleClass>();
    }
}

using UnityEngine;

using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Factory/Example")]
public class ExampleFactorySO : FactorySO<GameObject>
{
    public override GameObject Create()
    {
        return new GameObject("Example");
    }
}

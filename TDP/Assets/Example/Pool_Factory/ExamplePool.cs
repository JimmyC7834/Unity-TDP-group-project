using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Framework.Pool;
using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Pool/Example")]
public class ExamplePool : ComponentPoolSO<ExampleClass>
{
    public ExampleFactorySO _factory;

    public override IFactory<ExampleClass> Factory
    {
        get
        {
            return _factory;
        }
        set
        {
            _factory = value as ExampleFactorySO;
        }
    }
}

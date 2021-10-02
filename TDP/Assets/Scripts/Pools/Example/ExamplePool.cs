using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Framework.Pool;
using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Pool/Example")]
public class ExamplePool : PoolSO<GameObject>
{
    public ExampleFactorySO _factory;

    public override IFactory<GameObject> Factory
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

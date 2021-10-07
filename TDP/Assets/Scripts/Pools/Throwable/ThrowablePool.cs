using System.Collections;
using UnityEngine;

using Game.Framework.Pool;
using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Pool/Throwable")]
public class ThrowablePool : ComponentPoolSO<ThrowableObject>
{
    [SerializeField] private ThrowableFactory _factory;

    public override IFactory<ThrowableObject> Factory
    {
        get
        {
            return _factory;
        }
        set
        {
            _factory = value as ThrowableFactory;
        }
    }
}

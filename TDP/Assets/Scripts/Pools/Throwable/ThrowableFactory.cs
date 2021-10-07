using UnityEngine;

using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Factory/Throwable")]
public class ThrowableFactory : FactorySO<ThrowableObject>
{
    public ThrowableObject throwableObject;

    public override ThrowableObject Create()
    {
        return (Instantiate(throwableObject.gameObject) as GameObject).GetComponent<ThrowableObject>();
    }
}

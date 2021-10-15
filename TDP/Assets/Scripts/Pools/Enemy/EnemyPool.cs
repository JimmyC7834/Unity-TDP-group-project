using System;
using UnityEngine;

using Game.Framework.Pool;
using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Pool/Enemy")]
public class EnemyPool : ComponentPoolSO<EnemyController>
{
    public EnemyFactory _factory;
    [SerializeField] private EnemyInfo[] enemyData = default;

    public enum Type { slime, slime_fire, COUNT };
    [Serializable]
    public struct EnemyInfo
    {
        public Type type;
        public EnemyData data;
    }

    public override IFactory<EnemyController> Factory
    {
        get
        {
            return _factory;
        }

        set
        {
            _factory = value as EnemyFactory;
        }
    }

    public EnemyController Request(Type type) {
        EnemyController newObj = base.Request();
        newObj.Initialize(enemyData[(int)type].data);
        return newObj;
    }
}

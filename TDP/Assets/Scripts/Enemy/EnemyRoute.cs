using UnityEngine;

public class EnemyRoute : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;

    public EnemyRouteNode[] nodes = default;

    private void OnValidate() {
        nodes = GetComponentsInChildren<EnemyRouteNode>();
    }

    public void SpawnEnemy(EnemyPool.Type type)
    {
        _pool.Request(type);
    }
}

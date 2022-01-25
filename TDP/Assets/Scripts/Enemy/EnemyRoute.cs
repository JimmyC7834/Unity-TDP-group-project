using UnityEngine;

public class EnemyRoute : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;

    public EnemyRouteNode[] nodes = default;

    [Header("Listening To")]
    [SerializeField] private EnemyEventChannel _returnEnemyToPool = default;

    private void Awake()
    {
        _returnEnemyToPool.OnEventRaised += (enemy) => _pool.Return(enemy);
    }

    private void OnValidate()
    {
        nodes = GetComponentsInChildren<EnemyRouteNode>();
    }

    // debug code, will improve
    public void SpawnEnemy(int type) => SpawnEnemy((EnemyPool.Type) type);

    public void SpawnEnemy(EnemyPool.Type type)
    {
        EnemyController enemy = _pool.Request(type);
        enemy.transform.position = transform.position;
        enemy.nextPoint = nodes[0].transform;
    }
}

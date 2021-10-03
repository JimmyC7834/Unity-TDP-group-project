using System.Collections;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    // store prefabs of ResourceObjects, in the order of ResourceObject.Type
    [SerializeField] private ResourceObjectPool _pool = default;

    [Header("Spawner Settings")]
    [SerializeField] private float timeInterval = default;
    [SerializeField] private ResourceObject.Type resourceType = default;
    [SerializeField] private float spawnVerticalVelocity = default;
    [SerializeField] private float noSpawnRadius = default;
    [SerializeField] private float spawnRadius = default;
    [SerializeField] private float limitCheckRadius = default;
    [SerializeField] private int limitCount = default;
    [SerializeField] private int preWarmNum = default;

    [Space]
    [Header("Debug Values")]
    [SerializeField] private int resourceCountInRange;
    [SerializeField] private bool stopped = false;

    private void OnEnable()
    {
        // pre fill the range with resources
        for (int i = 0; i < preWarmNum; i++)
        {
            RandomlySpawnResource(resourceType);
        }

        _pool.SetParent(transform);
        StartCoroutine(SpawnResourceAfterSec(timeInterval));
    }

    private void Update()
    {
        // if currently stopped but should spawn resource, continue
        if (stopped && ShouldSpawnResource())
        {
            stopped = false;
            StartCoroutine(SpawnResourceAfterSec(timeInterval));
        }
    }

    private IEnumerator SpawnResourceAfterSec(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        RandomlySpawnResource(resourceType);

        // check if limit is reached
        if (ShouldSpawnResource())
        {
            StartCoroutine(SpawnResourceAfterSec(timeInterval));
        }
        else
        {
            stopped = true;
        }
    }

    private bool ShouldSpawnResource() {
        resourceCountInRange = Physics2D.OverlapCircleAll(transform.position, limitCheckRadius, LayerMask.GetMask("ResourceObject")).Length;
        return resourceCountInRange < limitCount;
    }

    private void RandomlySpawnResource(ResourceObject.Type type)
    {
        float a = Random.Range(0, 2 * Mathf.PI);
        float r = Random.Range(noSpawnRadius, spawnRadius);
        SpawnResourceObject(type, (Vector2) transform.position + new Vector2(Mathf.Cos(a), Mathf.Sin(a)) * r);
    }

    private void SpawnResourceObject(ResourceObject.Type type, Vector2 position)
    {
        ResourceObject resource = _pool.Request();
        resource.transform.position = position;
        resource.GetComponent<ThrowableObject>().Launch(Vector2.zero, spawnVerticalVelocity, .5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
        Gizmos.DrawWireSphere(transform.position, noSpawnRadius);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, limitCheckRadius);
        Gizmos.color = Color.white;
    }
}

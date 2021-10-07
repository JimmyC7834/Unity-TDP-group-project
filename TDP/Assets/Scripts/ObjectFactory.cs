using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private TimerTrigger spawnTimer = default;
    [SerializeField] private InteractableObject interactable;
    [SerializeField] private ThrowablePool _pool = default;

    [Header("Spawn Values")]
    [SerializeField] private RecipeSO recipe = default;
    [SerializeField] private Transform spawnPoint = default;
    [SerializeField] private float spawnTime = default;
    [SerializeField] private float spawnHeight = default;
    [SerializeField] private float spawnVerticalVelocity = default;

    [Header("Debug Values")]
    [SerializeField] private int[] resourceCount;

    private void OnEnable()
    {
        interactable = GetComponent<InteractableObject>();
    }

    private void Awake()
    {
        resourceCount = new int[(int) ResourceObject.Type.COUNT];

        spawnTimer.enabled = false;
        spawnTimer.SetTimeInterval(spawnTime);

        interactable.OnInteracted += HandleInteract;
    }

    public void SpawnObject()
    {
        recipe.ConsumeIngredients(resourceCount);
        ThrowableObject throwable = _pool.Request();
        throwable.transform.position = spawnPoint.position;
        throwable.Throw(Vector2.zero, spawnVerticalVelocity, spawnHeight);

        if (!recipe.Craftable(resourceCount))
        {
            Debug.Log($"{name}: craftable: {recipe.Craftable(resourceCount)}");
            spawnTimer.enabled = false;
        }

    }

    private void HandleInteract(InteractableObject.InteractInfo info)
    {
        ResourceObject resource;
        if (info.pickedObject != null && (resource = info.pickedObject.GetComponent<ResourceObject>()) != null)
        {
            // get the resource from the player
            info.pickedObject.Throw(Vector2.zero, 0, 0);
            resource.ReturnToPool();

            // check if resources is enough for a spawn
            resourceCount[(int) resource.type]++;
            if (recipe.Craftable(resourceCount))
            {
                spawnTimer.enabled = true;
            }
        }
    }
}

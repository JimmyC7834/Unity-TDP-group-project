using UnityEngine;

[RequireComponent(typeof(ThrowableObject))]
public class ResourceObject : MonoBehaviour
{
    public enum Type { type1, type2, COUNT };
    public Type type = default;
    public ThrowableObject throwableObject = default;
    [SerializeField] private SpriteRenderer spriteRenderer = default;

    [Header("Broadcasting On")]
    [SerializeField] private ResourceObjectEventChannel returnResourceObject = default;

    private void OnEnable()
    {
        if (gameObject.layer != LayerMask.NameToLayer("ResourceObject"))
            gameObject.layer = LayerMask.NameToLayer("ResourceObject");
    }

    private void Awake()
    {
        throwableObject = GetComponent<ThrowableObject>();
    }

    public void Initialize(ResourceObjectPool.ResourceObjectInfo info)
    {
        type = info.type;
        spriteRenderer.sprite = info.sprite;
    }

    public void ReturnToPool() => returnResourceObject.RaiseEvent(this);
}

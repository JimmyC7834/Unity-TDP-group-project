using UnityEngine;

[RequireComponent(typeof(ThrowableObject))]
public class ResourceObject : MonoBehaviour
{
    public enum Type { type1, type2, COUNT };
    public Type type = default;
    [SerializeField] private SpriteRenderer spriteRenderer = default;

    private void OnEnable() {
        if (gameObject.layer != LayerMask.NameToLayer("ResourceObject"))
            gameObject.layer = LayerMask.NameToLayer("ResourceObject");
    }

    public void Initialize(ResourceObjectPool.ResourceObjectInfo info)
    {
        type = info.type;
        spriteRenderer.sprite = info.sprite;
    }
}

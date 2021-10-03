using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    public enum Type { type1, type2, COUNT };
    public Type type = default;
    [SerializeField] private SpriteRenderer spriteRenderer = default;

    public void Initialize(ResourceObjectPool.ResourceObjectInfo info)
    {
        type = info.type;
        spriteRenderer.sprite = info.sprite;
    }
}

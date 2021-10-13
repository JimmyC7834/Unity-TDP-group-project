using UnityEngine;

using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Factory/ResourceObject")]
public class ResourceObjectFactory : FactorySO<ResourceObject>
{
    [SerializeField] private GameObject resourcePrefab = default;

    public override ResourceObject Create()
    {
        return (Instantiate(resourcePrefab) as GameObject).GetComponent<ResourceObject>();
    }
}

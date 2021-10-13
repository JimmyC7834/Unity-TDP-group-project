using System;
using UnityEngine;

using Game.Framework.Pool;
using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Pool/ResourceObject")]
public class ResourceObjectPool : ComponentPoolSO<ResourceObject>
{
    public ResourceObjectFactory _factory;
    [SerializeField] private ResourceObjectInfo[] resourceData = default;

    [Serializable]
    public struct ResourceObjectInfo
    {
        public ResourceObject.Type type;
        public Sprite sprite;
    }

    public override IFactory<ResourceObject> Factory
    {
        get
        {
            return _factory;
        }

        set
        {
            _factory = value as ResourceObjectFactory;
        }
    }

    public ResourceObject Request(ResourceObject.Type type) {
        ResourceObject newObj = base.Request();
        newObj.Initialize(resourceData[(int)type]);
        return newObj;
    }
}

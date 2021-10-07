using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class ObjectFactory : MonoBehaviour
{
    [SerializeField] private InteractableObject interactable;
    [SerializeField] private int[] resourceCount;

    private void OnEnable()
    {
        interactable = GetComponent<InteractableObject>();
    }

    private void Awake() {
        interactable.OnInteracted += HandleInteract;
        resourceCount = new int[(int) ResourceObject.Type.COUNT];
    }

    private void HandleInteract(InteractableObject.InteractInfo info)
    {
        // get the resource from the player
        ResourceObject resource;
        if (info.pickedObject != null && (resource = info.pickedObject.GetComponent<ResourceObject>()) != null)
        {
            resourceCount[(int) resource.type]++;
            info.pickedObject.Throw(Vector2.zero, 0, 0);
            resource.ReturnToPool();
        }
    }
}

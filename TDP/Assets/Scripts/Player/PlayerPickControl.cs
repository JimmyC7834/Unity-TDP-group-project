using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
public class PlayerPickControl : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private InputReader _inputReader = default;
    [SerializeField] private Rigidbody2D _rigidbody;

    [Header("Pickup and Throw")]
    [SerializeField] private Transform pickedTrans;
    [SerializeField] private ThrowableObject pickedObject;
    [SerializeField] private float pickUpHeight = default;
    [SerializeField] private float putDownHeight = default;
    [SerializeField] private float throwStrength = default;
    [SerializeField] private float interactDist = default;

    private void OnEnable()
    {
        player = GetComponent<PlayerControl>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _inputReader.interactEvent += HandleInteractInput;
    }

    private void HandleInteractInput()
    {
        if (pickedObject != null)
        {
            pickedObject.Throw(player.facingDir, throwStrength * player.moveDir.magnitude, putDownHeight);
            pickedObject = null;
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, player.facingDir, interactDist);
        Debug.DrawRay(_rigidbody.position, player.facingDir * interactDist, Color.green, .1f);
        if (hit)
        {
            // handle throwable's pickup
            ThrowableObject throwableObject = hit.rigidbody.gameObject.GetComponent<ThrowableObject>();
            if (throwableObject != null && pickedObject == null)
            {
                pickedObject = throwableObject;
                throwableObject.PickUpBy(pickedTrans, pickUpHeight);
            }
        }
    }
}

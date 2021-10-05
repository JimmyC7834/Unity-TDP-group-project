using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InteractableObject))]
public class ThrowableObject : FakeHeightObject
{
    public InteractableObject interactable;

    [Header("Throw and Pick up values")]
    [Tooltip("Slow down the player to x%")]
    public float slowMultiplier = default;
    [SerializeField] private float putDownDist = default;
    [SerializeField] private float putDownHeight = default;
    [SerializeField] private float pickUpHeight = default;

    [Header("bounce values")]
    [SerializeField] protected float bounceSpeedThreshold = default;
    [SerializeField] protected float bounceSlowMultiplier = default;
    [SerializeField] protected float initialVerticalVelocity = default;
    [SerializeField] private SpriteRenderer _sprite = default;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private Transform picker;

    public UnityAction OnThrown;
    public UnityAction OnPickedUp;

    private void OnEnable()
    {
        if (bodyTransform == null || shadowTransform == null)
        {
            Debug.LogWarning($"missing bodyTransform or shadowTransform, please check your object");
            gameObject.SetActive(false);
        }

        interactable = GetComponent<InteractableObject>();
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        GetComponent<InteractableObject>().OnInteracted += HandleOnInteracted;
    }

    private void HandleOnInteracted(InteractableObject.InteractInfo info)
    {
        PlayerControl player = info.interactor.player;

        // pick up this if the interactor didn't pick up an object
        if (info.pickedObject == null)
        {
            PickUpBy(info.interactor.pickedTrans, pickUpHeight);
            info.interactor.PickUpObject(this);
        }
        else if (info.pickedObject == this)
        {
            Throw(player.facingDir, info.interactor.throwStrength * player.moveDir.magnitude, putDownHeight);
        }
        else
        {
            info.pickedObject.Throw(player.facingDir, info.interactor.throwStrength * player.moveDir.magnitude, putDownHeight);
        }

    }

    protected override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (picker != null)
        {
            _rigidbody.position = picker.position;
        }

        // make the sprite larger is it's heighter
        _sprite.transform.localScale = Vector2.one * (1 + (bodyTransform.position.y - shadowTransform.position.y)/7.5f);
    }

    protected override void CheckGroundHit()
    {
        if (bodyTransform.position.y <= transform.position.y && !IsGrounded)
        {
            if (groundVelocity.magnitude > bounceSpeedThreshold)
            {
                Bounce();
            }
            else
            {
                IsGrounded = true;
                bodyTransform.position = transform.position;
                groundVelocity = Vector2.zero;
                EnableGroundPhysics();
            }
        }
    }

    private void EnableGroundPhysics()
    {
        _collider.isTrigger = false;
        _rigidbody.WakeUp();
    }

    private void DisableGroundPhysics()
    {
        _collider.isTrigger = true;
        _rigidbody.Sleep();
    }

    protected virtual void Bounce()
    {
        groundVelocity = groundVelocity * bounceSlowMultiplier;
        verticalVelocity = initialVerticalVelocity * bounceSlowMultiplier;
        EnableGroundPhysics();
    }

    public void Throw(Vector2 dir, float magnitude, float _initialHeight)
    {
        // put down the object if not moving
        if (magnitude == 0)
            transform.position += (Vector3)dir * putDownDist;

        picker = null;
        transform.SetParent(null);
        DisableGroundPhysics();
        Launch(dir * magnitude, magnitude, _initialHeight);
        initialVerticalVelocity = magnitude;

        OnThrown?.Invoke();
    }

    public void PickUpBy(Transform _picker, float _height)
    {
        DisableGroundPhysics();

        picker = _picker;

        transform.SetParent(_picker, true);
        bodyTransform.position += Vector3.up * _height;

        _rigidbody.Sleep();
        _isGrounded = true;

        OnPickedUp?.Invoke();
    }
}

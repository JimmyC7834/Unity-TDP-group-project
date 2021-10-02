using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ThrowableObject : FakeHeightObject
{
    [SerializeField] private float putDownDist = default;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform picker;

    private void OnEnable()
    {
        if (bodyTransform == null || shadowTransform == null)
        {
            Debug.LogWarning($"missing bodyTransform or shadowTransform, please check your object");
            gameObject.SetActive(false);
        }

        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (picker != null)
        {
            _rigidbody.position = picker.position;
        }
    }

    protected override void CheckGroundHit()
    {
        if (bodyTransform.position.y <= transform.position.y && !IsGrounded)
        {
            IsGrounded = true;
            bodyTransform.position = transform.position;
            EnableGroundPhysics();
        }
    }

    private void EnableGroundPhysics() {
        _collider.enabled = true;
        _rigidbody.WakeUp();
    }

    private void DisableGroundPhysics() {
        _collider.enabled = false;
        _rigidbody.Sleep();
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
    }

    public void PickUpBy(Transform _picker, float _height)
    {
        DisableGroundPhysics();

        picker = _picker;

        transform.SetParent(_picker, true);
        bodyTransform.position += Vector3.up * _height;

        _rigidbody.Sleep();
        _isGrounded = true;
    }
}

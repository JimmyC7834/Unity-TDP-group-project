using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = default;
    [SerializeField] private float speedMultiplier = 1;
    [SerializeField] private Vector2 startPoint;
    [SerializeField] public Transform nextPoint = default;

    [Space]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Sprite _bodySprite;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        startPoint = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.MovePosition(Vector2.MoveTowards(_rigidbody.position, (Vector2) nextPoint.position, speed * speedMultiplier * Time.fixedDeltaTime));
    }

    public void Initialize(EnemyData data) {
        _bodySprite = data.sprite;
        speed = data.speed;
    }

    public void RedirectTo(Transform targetPoint)
    {
        startPoint = nextPoint.position;
        nextPoint = targetPoint;
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = default;
    [SerializeField] private Vector2 moveDir;
    [SerializeField] private Vector2 facingDir = Vector2.up;
    [SerializeField] private float raycastDist = default;
    // [SerializeField] private float keepDiagonalDirTime = default;
    // [SerializeField] private float keepDiagonalDirTimer = 0;
    // [SerializeField] private bool keepingDiagonalDir = false;
    [SerializeField] private InputReader _inputReader = default;

    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // keepDiagonalDirTimer = keepDiagonalDirTime;

        _inputReader.moveEvent += HandleMoveInput;
        _inputReader.interactEvent += HandleInteractInput;
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }

    private void ProcessMovement()
    {
        _rigidbody.MovePosition(_rigidbody.position + speed * moveDir * Time.fixedDeltaTime);

        // keepingDiagonalDir = !(keepDiagonalDirTimer <= 0);
        // if (keepingDiagonalDir)
        //     keepDiagonalDirTimer -= Time.fixedDeltaTime;

    }

    private void HandleMoveInput(Vector2 dir)
    {
        moveDir = dir;

        if (moveDir.magnitude == 0)
            return;

        // if (Mathf.Abs(facingDir.x) == Mathf.Abs(facingDir.y))
        // {
        //     if (!keepingDiagonalDir)
        //     {
        //         transform.rotation = Quaternion.LookRotation(Vector3.back, moveDir);
        //         facingDir = moveDir;
        //         keepDiagonalDirTimer = keepDiagonalDirTime;
        //         keepingDiagonalDir = true;
        //     }
        // }
        // else
        // {
        // }
        transform.rotation = Quaternion.LookRotation(Vector3.back, moveDir);
        facingDir = moveDir;

    }

    private void HandleInteractInput()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, facingDir, raycastDist);
        Debug.DrawRay(_rigidbody.position, facingDir * raycastDist, Color.green, .1f);
        if (hit)
        {
            Debug.Log($"{name} interacted facing {facingDir} hitted");
        }
    }
}

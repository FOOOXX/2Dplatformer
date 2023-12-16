using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private RaycastHit2D _hit;

    private float _moveSpeed;
    private float _jumpForce;
    private float _rayDistance;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _rayDistance = 0.42f;
        _moveSpeed = 4f;
        _jumpForce = 230f;
    }

    private void FixedUpdate()
    {
        Move();

        if (IsGround() == false)
            return;

        Jump();
    }

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.down * _rayDistance, Color.red);
    }

    private void Move()
    {
        float horizontalDirection = Input.GetAxisRaw(Horizontal);

        transform.Translate(_moveSpeed * Time.deltaTime * horizontalDirection * transform.right);

        _animator.SetFloat("Speed", Mathf.Abs(horizontalDirection));

        if (horizontalDirection > 0 && _spriteRenderer.flipX)
            Flip();
        else if (horizontalDirection < 0 && !_spriteRenderer.flipX)
            Flip();
    }

    private void Jump()
    {
        float verticalDirection = Input.GetAxisRaw(Vertical);

        Vector2 move = new(0f, verticalDirection);

        _rigidbody2D.AddForce(_jumpForce * move, ForceMode2D.Force);
    }

    private void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    private bool IsGround()
    {
        _hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));

        return _hit.collider != null;
    }
}

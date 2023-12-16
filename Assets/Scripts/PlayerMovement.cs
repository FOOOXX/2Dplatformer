using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CoinCounter))]

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private RaycastHit2D _hit;
    private CoinCounter _coinCounter;

    private float _moveSpeed;
    private float _jumpForce;
    private float _rayDistance;
    private float _horizontalDirection;
    private float _verticalDirection;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _coinCounter = GetComponent<CoinCounter>();
    }

    private void Start()
    {
        _rayDistance = 0.42f;
        _moveSpeed = 4f;
        _jumpForce = 230f;
    }

    private void FixedUpdate()
    {
        _horizontalDirection = Input.GetAxisRaw(Horizontal);
        _verticalDirection = Input.GetAxisRaw(Vertical);

        Move();

        if (IsGround() == false)
            return;

        Jump();

        StartAnimation();
    }

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.down * _rayDistance, Color.red);
    }

    private void Move()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * _horizontalDirection * transform.right);

        if (_horizontalDirection > 0 && _spriteRenderer.flipX)
            Flip();
        else if (_horizontalDirection < 0 && !_spriteRenderer.flipX)
            Flip();
    }

    private void Jump()
    {
        Vector2 move = new(0f, _verticalDirection);

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coinCounter.AddMoney();

            Destroy(collision.gameObject);
        }
    }

    private void StartAnimation()
    {
        if (_horizontalDirection != 0)
        {
            _animator.SetBool("IsRunning", true);
            return;
        }

        _animator.SetBool("IsRunning", false);
    }
}

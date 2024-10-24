using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;             // �������� �����������
    [SerializeField] private float _jumpForce = 5f;             // ���� ������
    [SerializeField] private float _groundCheckDistance = 0.1f; // ���������� ��� �������� ������� �����
    [SerializeField] private LayerMask _groundLayer;            // ���� �����
    [SerializeField] private Transform _groundCheck;            // ����� �������� ������� �����
    
    private bool _isGrounded;                                   // ����, �� ����� �� �����
    private PlayerInput _playerInput;
    private Rigidbody _playerRigidbody;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        Vector2 movementInput = _playerInput.GetMovementInput();
        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        moveDirection = transform.TransformDirection(moveDirection);

        // ����������� ����� ��������� �������� Rigidbody
        Vector3 newVelocity = new Vector3(moveDirection.x * _moveSpeed, _playerRigidbody.velocity.y, moveDirection.z * _moveSpeed);
        _playerRigidbody.velocity = newVelocity;
    }

    void HandleJump()
    {
        // ���������, ��������� �� ����� �� �����
        _isGrounded = Physics.Raycast(_groundCheck.position, Vector3.down, _groundCheckDistance, _groundLayer);
        if (_isGrounded)
        {
            Debug.Log("����� �� �����");
        }

        // ������������ ������
        if (_isGrounded && _playerInput.GetJumpInput())
        {
            Debug.Log("������ ������");
            _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}

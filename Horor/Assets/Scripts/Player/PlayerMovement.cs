using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;             // Скорость перемещения
    [SerializeField] private float _jumpForce = 5f;             // Сила прыжка
    [SerializeField] private float _groundCheckDistance = 0.1f; // Расстояние для проверки касания земли
    [SerializeField] private LayerMask _groundLayer;            // Слой земли
    [SerializeField] private Transform _groundCheck;            // Точка проверки касания земли
    
    private bool _isGrounded;                                   // Флаг, на земле ли игрок
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

        // Перемещение через изменение скорости Rigidbody
        Vector3 newVelocity = new Vector3(moveDirection.x * _moveSpeed, _playerRigidbody.velocity.y, moveDirection.z * _moveSpeed);
        _playerRigidbody.velocity = newVelocity;
    }

    void HandleJump()
    {
        // Проверяем, находится ли игрок на земле
        _isGrounded = Physics.Raycast(_groundCheck.position, Vector3.down, _groundCheckDistance, _groundLayer);
        if (_isGrounded)
        {
            Debug.Log("Игрок на земле");
        }

        // Обрабатываем прыжок
        if (_isGrounded && _playerInput.GetJumpInput())
        {
            Debug.Log("Прыжок нажали");
            _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}

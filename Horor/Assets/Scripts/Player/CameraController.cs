using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;     // Ссылка на объект игрока (тело)
    [SerializeField] private float _mouseSensitivity = 2f;   // Чувствительность мыши

    private float xRotation = 0f;                            // Текущий вертикальный угол поворота камеры
    private PlayerInput _playerInput;     

    private void Awake()
    {        
        _playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {      
        // Блокируем курсор в центре экрана и скрываем его
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        Vector2 mouseInput = _playerInput.GetMouseInput();
        xRotation -= mouseInput.y * _mouseSensitivity;
        // Ограничиваем вращение камеры вверх/вниз
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  
        _cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Вращение персонажа по оси Y
        transform.Rotate(Vector3.up * mouseInput.x * _mouseSensitivity);  
    }
}

using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;     // ������ �� ������ ������ (����)
    [SerializeField] private float _mouseSensitivity = 2f;   // ���������������� ����

    private float xRotation = 0f;                            // ������� ������������ ���� �������� ������
    private PlayerInput _playerInput;     

    private void Awake()
    {        
        _playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {      
        // ��������� ������ � ������ ������ � �������� ���
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
        // ������������ �������� ������ �����/����
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  
        _cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // �������� ��������� �� ��� Y
        transform.Rotate(Vector3.up * mouseInput.x * _mouseSensitivity);  
    }
}

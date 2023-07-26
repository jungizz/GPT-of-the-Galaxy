using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 1.5f;

    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private float gravityValue;

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void OnEnable() => jumpButton.action.performed += Jumping;

    private void OnDisable() => jumpButton.action.performed -= Jumping;

    void Start() => gravityValue = GetComponent<ConstantForce>().force.y;

    private void Jumping(InputAction.CallbackContext obj)
    {
        if (!_characterController.isGrounded) return;
        _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

    private void Update()
    {
        if (_characterController.isGrounded && _playerVelocity.y < 0) _playerVelocity.y = 0f;

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }
}

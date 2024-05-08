using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public float mouseSensitivity = 1f;
    public Transform theCamera;
    private Vector3 _moveInput;
    private CharacterController _characterController;
    private Vector3 _startingPosition;
    [SerializeField] private Animator _playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 forwardDirection = transform.forward * verticalInput;
        Vector3 horizontalDirection = transform.right * horizontalInput;

        _moveInput = (forwardDirection + horizontalDirection).normalized;
        _moveInput *= moveSpeed;

        //Player Animations
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        _playerAnimator.SetFloat("InputMagnitude", inputMagnitude, 0.05f, Time.deltaTime);
        _characterController.Move(_moveInput * Time.deltaTime);

        //Camera rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        theCamera.rotation = Quaternion.Euler(theCamera.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
    }
        
}
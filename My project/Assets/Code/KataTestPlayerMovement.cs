using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KataTestPlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference JumpControl;

    private bool PlayerGrounded;

    private Vector3 playerVelocity;
    //private Vector3 Movement;
    private Vector3 Input;

    public Transform cameraMainTransform;
    
    private CharacterController characterController;

    public float speed = 5f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private float rotationSpeed = 4f;



    private void OnEnable()
    {
        movementControl.action.Enable();
        JumpControl.action.Enable();
    }
    private void OnDisable()
    {
        movementControl.action.Disable();
        JumpControl.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        
        cameraMainTransform = Camera.main.transform;
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Checks if player is grounded from character contoller and puts players y velocity to 0.
        PlayerGrounded = characterController.isGrounded;
        if(PlayerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;  
        }
        // Reads players inputs from new input system.
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 Move = new Vector3(movement.x, 0, movement.y);

        // This moves the player towards what point camera is looking not what way the character is looking.
        Move = cameraMainTransform.forward * Move.z + cameraMainTransform.right * Move.x;
        Move.y = 0;
        characterController.Move(Move * Time.deltaTime * speed);
        
        // If player has pressed jump button and is grounded add y velocity to player.
        if (JumpControl.action.triggered && PlayerGrounded == true)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        
        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        // Handles players rotation.
        if(movement != Vector2.zero)
		{
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}
        
        
    }
}

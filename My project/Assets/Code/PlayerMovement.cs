using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference JumpControl;
    [SerializeField] private InputActionReference Inventory;

    [SerializeField] private GameObject InventoryUI;

    public CinemachineFreeLook freeLook;

    public GameObject JournalCanvas;
    private bool inventoryOpen = false;

    private bool PlayerGrounded;

    public CheckTerrainTexture terrainCheck;

    private Vector3 playerVelocity;
    //private Vector3 Movement;
    private Vector3 Input;

    public Transform cameraMainTransform;
    
    private CharacterController characterController;

    public float speed = 5f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private float rotationSpeed = 4f;
    private float currentSpeed = 0f;

    private Animator anim;

    public Quest quest;

    public delegate void TalkEventHandler(GameObject npc);
    public static event TalkEventHandler WhoTalkedTo;



    private void OnEnable()
    {
        movementControl.action.Enable();
        JumpControl.action.Enable();
        Inventory.action.Enable();
    }
    private void OnDisable()
    {
        movementControl.action.Disable();
        JumpControl.action.Disable();
        Inventory.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        
        cameraMainTransform = Camera.main.transform;

        anim = GetComponent<Animator>();

        
    }

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("NPC"))
        {
            TalkedTo(other.gameObject);
        }
    }

    public static void TalkedTo(GameObject npc)
    {
        if(npc != null)
        {
            if(WhoTalkedTo != null)
            {
                WhoTalkedTo(npc);
            }
            Debug.Log(npc);
           
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(Terrain.activeTerrain.terrainData.terrainLayers);
    }

    private void Update()
    {
        if (Inventory.action.WasPerformedThisFrame())
        {
            if (inventoryOpen == false)
            {
                inventoryOpen = true;
                InventoryUI.SetActive(true);
                InventoryManager.Instance.ListItems();
                JournalCanvas.SetActive(true);
                Cursor.visible = true;
                freeLook.enabled = false;
            }
            else
            {
                inventoryOpen = false;
                InventoryUI.SetActive(false);
                JournalCanvas.SetActive(false);
                Cursor.visible = false;
                freeLook.enabled = true;
            }
        }
    }

    public void RightFoot()
	{
        terrainCheck.GetTerrainTexture();
        if (terrainCheck.textureValues[0] > 0)
        {
            //Debug.Log("Grass");
            AudioManager.Instance.RandomSoundEffect(terrainCheck.grassSteps);
        }
        if (terrainCheck.textureValues[1] > 0)
        {
            //Debug.Log("Grass2");
            AudioManager.Instance.RandomSoundEffect(terrainCheck.grassSteps);
        }
        if (terrainCheck.textureValues[2] > 0)
        {
            AudioManager.Instance.RandomSoundEffect(terrainCheck.dirtSteps);
        }
        if (terrainCheck.textureValues[3] > 0)
        {
            AudioManager.Instance.RandomSoundEffect(terrainCheck.dirtSteps);
        }
        if (terrainCheck.textureValues[4] > 0)
        {
            //Debug.Log("Sand");
            AudioManager.Instance.RandomSoundEffect(terrainCheck.sandSteps);
        }
    }

    public void LeftFoot()
	{
        terrainCheck.GetTerrainTexture();
        if (terrainCheck.textureValues[0] > 0)
        {
            //Debug.Log("Grass");
            AudioManager.Instance.RandomSoundEffect(terrainCheck.grassSteps);
        }
        if (terrainCheck.textureValues[1] > 0)
        {
            //Debug.Log("Grass2");
            AudioManager.Instance.RandomSoundEffect(terrainCheck.grassSteps);
        }
        if (terrainCheck.textureValues[2] > 0)
        {
            //Debug.Log("Dirt");
        }
        if (terrainCheck.textureValues[3] > 0)
        {
            //Debug.Log("Dirt with grass");
        }
        if (terrainCheck.textureValues[4] > 0)
        {
            //Debug.Log("Sand");
            AudioManager.Instance.RandomSoundEffect(terrainCheck.sandSteps);
        }
    }
    void FixedUpdate()
    {
       
        // Reads players inputs from new input system.
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 Move = new Vector3(movement.x, 0, movement.y);
        Move.y = 0;
        // This moves the player towards what point camera is looking not what way the character is looking.
        Move = cameraMainTransform.forward * Move.z + cameraMainTransform.right * Move.x;
        Move.y = 0;
        characterController.Move(Move * Time.deltaTime * speed);

        // Gets charactercontrollers speed and passes it to currentSpeed so can check if going above 0 float so can play right anim.
        currentSpeed = characterController.velocity.magnitude;
        // Checks if player is grounded from character contoller and puts players y velocity to 0.
        PlayerGrounded = characterController.isGrounded;
        if (PlayerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        // Sets animation controllers var speed to correspond charactercontrollers speed so plays right animation.
        if (currentSpeed > 0)
		{
            anim.SetFloat("Speed", 1f);
		}
		else
		{
            anim.SetFloat("Speed", 0f);
		}
        // If player has pressed jump button and is grounded add y velocity to player.
        if (JumpControl.action.WasPerformedThisFrame() && PlayerGrounded == true)
        {
            Debug.Log("Jumping");
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

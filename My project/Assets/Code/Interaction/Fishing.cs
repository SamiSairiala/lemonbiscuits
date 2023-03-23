using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fishing : MonoBehaviour
{
    public Item FishingRod;


    private float speed;
    private bool pressing = false;

    public GameObject fishingBob;
    public FishingProjectile projectile;
    [SerializeField] private InputActionReference fishingButton;

    public GameObject fishingRod;
    public GameObject playerChracter;
    // Start is called before the first frame update


    private void OnEnable()
    {
        fishingButton.action.Enable();
    }

    private void OnDisable()
    {
        fishingButton.action.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Instance.Items.Contains(FishingRod) && fishingButton.action.WasPressedThisFrame())
        {
            speed = 0;
            pressing = true;
            fishingRod.SetActive(true);
        }
        if(pressing == true)
        {
            speed += Time.deltaTime * 30;
        }
        if(InventoryManager.Instance.Items.Contains(FishingRod) && fishingButton.action.WasReleasedThisFrame())
        {
            pressing = false;
            Instantiate(fishingBob, playerChracter.transform.localPosition, playerChracter.transform.localRotation);
            projectile.speed = speed;
            fishingRod.SetActive(false);
            Debug.Log(speed);
        }
    }
}

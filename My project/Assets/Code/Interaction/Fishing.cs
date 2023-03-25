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
    [SerializeField] private float radius = 1f;

    public bool isFishing = false;
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
        if (InventoryManager.Instance.Items.Contains(FishingRod) && fishingButton.action.WasPressedThisFrame() && isFishing == false)
        {
            speed = 0;
            pressing = true;
            
            fishingRod.SetActive(true);
        }
        if(pressing == true)
        {
            speed += Time.deltaTime * 100;
        }
        if(InventoryManager.Instance.Items.Contains(FishingRod) && fishingButton.action.WasReleasedThisFrame() && isFishing == false)
        {
            pressing = false;
            isFishing = true;
            Instantiate(fishingBob, fishingRod.transform.position, fishingRod.transform.rotation);
			Rigidbody rb = fishingBob.GetComponent<Rigidbody>();
            projectile.speed = speed;
			fishingRod.SetActive(false);
			Debug.Log(speed);
        }
    }
}

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
    public GameObject FishingRodEnd;

    public Color c1;

    public bool isFishing = false;

    private LineRenderer lr;
    private GameObject FishingLine;
    private GameObject fishingLure;

    [SerializeField] private Material fishingLineMaterial;

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
            projectile.speed = speed;
            fishingLure = Instantiate(fishingBob, fishingRod.transform.position, fishingRod.transform.rotation);
            projectile.speed = speed;
            //Instantiate(fishingBob, fishingRod.transform.position, fishingRod.transform.rotation);
            FishingLine = new GameObject("fishingLine");
            lr = FishingLine.AddComponent<LineRenderer>();
            Rigidbody rb = fishingBob.GetComponent<Rigidbody>();
            //projectile.speed = speed;
			Debug.Log(speed);
        }
        if (fishingRod.activeInHierarchy && isFishing == true)
        {
            GameObject fishingLine = GameObject.Find("fishingLine");
            fishingLine.GetComponent<LineRenderer>().SetPosition(0, FishingRodEnd.transform.position);
            fishingLine.GetComponent<LineRenderer>().SetPosition(1, fishingLure.transform.position);
            fishingLine.GetComponent<LineRenderer>().SetWidth(0.01f, 0.01f);
            fishingLine.GetComponent<LineRenderer>().SetColors(c1, c1);
            fishingLine.GetComponent<LineRenderer>().material = fishingLineMaterial;
            //lr.SetPosition(0, FishingRodEnd.transform.position);
            //lr.SetPosition(1, fishingLure.transform.position);
            //lr.SetWidth(0.01f, 0.01f);
            //lr.material = new Material(Shader.Find("Particles/Additive"));
            //lr.SetColors(c1, c1);
        }
        else if(!fishingRod.activeInHierarchy)
            {
            Destroy(FishingLine);
            }
    }
}

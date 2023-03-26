using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingProjectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField] private float radius = 1f;
    private Rigidbody rigidBody;

    public GameObject player;

    private bool Return = false;

    public float ReturnSpeed = 0.3f;
    [SerializeField] private Fishing fishing;

    public Item fish;

    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;

    void Start()
    {
        fish = null;
        Return = false;
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Playercharacter");
        fishing = FindObjectOfType<Fishing>();
        StartCoroutine(ComeBackToPlayer());
        Launch();
    }


    void Launch()
    {
        rigidBody.AddExplosionForce(speed, transform.position, radius, 3f);
        rigidBody.AddForce(transform.forward * speed);
        
    }
    
    void Update()
    {
        if(Return == true)
		{
			//transform.Translate(player.transform.position * ReturnSpeed * Time.deltaTime);
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, ReturnSpeed);
		}
    }

    IEnumerator ComeBackToPlayer()
	{
        yield return new WaitForSeconds(5.0f);
        MoveBackToPlayer();
        StartCoroutine(DestroyIfNotReached());
        
    }

    IEnumerator DestroyIfNotReached()
	{
        yield return new WaitForSeconds(2.0f);
        Return = true;
        if (fish != null)
        {
            ItemAddedToInventory(fish);
            InventoryManager.Instance.Add(fish);
        }
        Destroy(gameObject);
        fishing.isFishing = false;
    }

    void MoveBackToPlayer()
	{
        Debug.Log("Moving");
        Return = true; // Change this
        
    }

   
    
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
            if(fish != null)
			{
                ItemAddedToInventory(fish);
                InventoryManager.Instance.Add(fish);
			}
            fishing.isFishing = false;
            GameObject.Destroy(gameObject);
            Debug.Log("Came Back");
		}
	}

    public static void ItemAddedToInventory(Item item)
    {
        if (OnItemAddedToInventory != null)
        {
            OnItemAddedToInventory(item);
            Debug.Log(item);
        }

    }
}

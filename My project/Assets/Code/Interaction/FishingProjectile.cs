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
    void Start()
    {
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
        yield return new WaitForSeconds(3.0f);
        MoveBackToPlayer();
        
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
                InventoryManager.Instance.Add(fish);
			}
            fishing.isFishing = false;
            GameObject.Destroy(gameObject);
            Debug.Log("Came Back");
		}
	}
}

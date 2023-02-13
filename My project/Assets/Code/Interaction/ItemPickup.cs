using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
	public bool Collected = false;
    void Pickup()
	{
		InventoryManager.Instance.Add(Item);
		Destroy(gameObject);
	}
	

	//TODO: Implement some way of picking up items.
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Pickup();
		}
	}
}

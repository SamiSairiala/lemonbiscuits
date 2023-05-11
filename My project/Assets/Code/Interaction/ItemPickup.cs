using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
	public bool Collected = false;
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    void Pickup()
	{
        ItemAddedToInventory(Item);
		InventoryManager.Instance.Add(Item);
		Destroy(gameObject);

	}

    public static void ItemAddedToInventory(Item item)
    {
        if (OnItemAddedToInventory != null)
		{
            OnItemAddedToInventory(item);
            Debug.Log(item);
        }
           
    }


    //TODO: Implement some way of picking up items.
    private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if (this.gameObject.name.Equals("Amulet"))
			{
				FindObjectOfType<NightQuest>().Amulet = null;
				FindObjectOfType<NightQuest>().QuestActive = false;
				FindObjectOfType<NightQuest>().Footsteps1.SetActive(false);
				FindObjectOfType<NightQuest>().Footsteps2.SetActive(false);
				FindObjectOfType<NightQuest>().Footsteps3.SetActive(false);
			}
			Pickup();
		}
	}

	
}

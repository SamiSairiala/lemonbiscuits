using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBond : MonoBehaviour
{

	public List<Item> Fishes;

	private FishingProjectile fishingBob;

	private int Randomindex;
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals("Fishing"))
		{
			fishingBob = FindObjectOfType<FishingProjectile>();
			Randomindex = Random.Range(0, Fishes.Count);
			fishingBob.fish = Fishes[Randomindex];
		}
	}
}

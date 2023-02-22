using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

	public Vector3 vPlayerPos; // Used for saving / loading player position.
	public List<Item> items; // Used for saving / loading player inventory.

	public GameData()
	{
		vPlayerPos = Vector3.zero;
		items = new List<Item>();
	}
}

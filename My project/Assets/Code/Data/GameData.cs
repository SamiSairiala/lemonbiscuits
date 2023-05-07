using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

	public Vector3 vPlayerPos; // Used for saving / loading player position.
	public List<Item> items; // Used for saving / loading player inventory.
	public List<Item> Inventoryitems; // Used for saving / loading player inventory.
	public bool firstquestComplete;
	public bool secondquestComplete;
	public bool thirdquestComplete;
	public bool fourthquestComplete;
	public bool fifthquestComplete;
	public string Playername;

	public GameData()
	{
		vPlayerPos = Vector3.zero;
		//items = new List<Item>();
		//Inventoryitems = new List<Item>();
		if(firstquestComplete == true)
        {
			firstquestComplete = true;
        }
		Playername = "";
	}
}

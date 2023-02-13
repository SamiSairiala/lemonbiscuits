using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

	public Vector3 vPlayerPos;
	public List<Item> items;

    public GameData()
	{
		vPlayerPos = Vector3.zero;
		items = new List<Item>();
	}
}

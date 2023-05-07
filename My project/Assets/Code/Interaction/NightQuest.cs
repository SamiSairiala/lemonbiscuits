using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LemonForest.Environment.DayTime;

public class NightQuest : MonoBehaviour
{

	public GameObject Amulet;
	public bool QuestActive = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Amulet != null)
		{
			if (QuestActive)
			{

				Debug.Log("NightQuest active");
				if (TimeStateManager.Instance.CurrentState.Type.Equals(DayState.Midnight))
				{
					Amulet.SetActive(true);
				}
				else
				{
					Amulet.SetActive(false);
				}
			}
		}
	}
}

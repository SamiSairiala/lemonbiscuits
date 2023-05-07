using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BeetlesTrigger : MonoBehaviour
{
	public GameObject spawnPoint;
	public GameObject proof;
	[SerializeField] private InputActionReference Interaction;
	public GameObject clearBeetlesCanvas;
	private bool CanClear = false;


	private void OnEnable()
	{
		Interaction.action.Enable();
		
	}
	private void OnDisable()
	{
		Interaction.action.Disable();
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			clearBeetlesCanvas.SetActive(true);
			CanClear = true;
			
		}
	}

	private void Update()
	{
		if (CanClear)
		{
			if (Interaction.action.WasPerformedThisFrame())
			{
				CanClear = false;
				Instantiate(proof, spawnPoint.transform.position, Quaternion.identity);
				clearBeetlesCanvas.SetActive(false);
				this.gameObject.SetActive(false);
				
			}
		}
	}
}

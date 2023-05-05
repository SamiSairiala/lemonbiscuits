using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BeetlesTrigger : MonoBehaviour
{
	public GameObject spawnPoint;
	public GameObject proof;
	[SerializeField] private InputActionReference Interaction;



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
			if (Interaction.action.triggered)
			{
				Instantiate(proof, spawnPoint.transform.position, Quaternion.identity);
				this.gameObject.SetActive(false);
			}
			
		}
	}

	private void Start()
	{
		
	}
}

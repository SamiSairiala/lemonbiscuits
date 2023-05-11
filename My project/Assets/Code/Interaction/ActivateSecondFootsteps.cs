using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSecondFootsteps : MonoBehaviour
{
    public GameObject Footsteps2;
    // Start is called before the first frame update
    void Start()
    {
        
    }


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
            Footsteps2.SetActive(true);
		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}

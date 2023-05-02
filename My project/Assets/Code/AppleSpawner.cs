using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject apple;

	// Start is called before the first frame update
	private void Start()
	{
		Randomize();
	}


	void Randomize()
	{
		int numberOfAppleObjects = GameObject.FindGameObjectsWithTag("Apple").Length;
		if(numberOfAppleObjects <= 4)
		{
			spawnApple();
		}
		else
		{
			StartCoroutine(DontSpawn());
		}
	}

	IEnumerator DontSpawn()
	{
		yield return new WaitForSeconds(20);
		Start();
	}

	void spawnApple()
	{
		Instantiate(apple, spawner.transform.position, Quaternion.identity);
		StartCoroutine(DontSpawn());
	}

    
}

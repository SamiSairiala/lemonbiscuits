using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuestItems : MonoBehaviour
{



    public GameObject[] spawnPoints;

    public GameObject Flower;

    // Start is called before the first frame update
    void Start()
    {
        Randomize();
    }

	private void Randomize()
	{
        int numberOfFlowerObjects = GameObject.FindGameObjectsWithTag("Flower").Length;
        Debug.Log(numberOfFlowerObjects);
        if (numberOfFlowerObjects <= 4)
        {
            Debug.Log("Spawning flowers");
            spawnApple();
        }
        else
        {
            Debug.Log("not Spawning flowers");
            StartCoroutine(DontSpawn());
        }
    }

    IEnumerator DontSpawn()
	{
        yield return new WaitForSeconds(10);
        Start();
    }

	private void spawnApple()
	{
        int rand = Random.Range(1, 10); // 9 spawn points
        Instantiate(Flower, spawnPoints[rand].transform.position, Quaternion.identity);
        StartCoroutine(DontSpawn());
    }

	
}

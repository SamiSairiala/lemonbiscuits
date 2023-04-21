using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRareFishingPond : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject RareFishingPond;



    // Start is called before the first frame update
    void Start()
    {
        SpawnPond();
    }

    public void SpawnPond()
    {
		if (RareFishingPond.activeInHierarchy)
		{
            Destroy(RareFishingPond);
		}
        int rand = Random.Range(1, 5);
        Instantiate(RareFishingPond, spawnPoints[rand].transform.position, Quaternion.Euler(180f,0f,0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

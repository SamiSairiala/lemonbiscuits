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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Flower.activeInHierarchy)
        {
            int rand = Random.Range(1, 10); // 9 spawn points
            Instantiate(Flower, spawnPoints[rand].transform.position, Quaternion.identity);
            
        }
    }
}

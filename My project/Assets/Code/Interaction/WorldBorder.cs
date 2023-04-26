using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = this.gameObject.transform.GetChild(0).gameObject;
        cc = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            cc.enabled = false;
            Debug.Log("Moving player back");
            player.transform.position = spawnPoint.transform.position;
            cc.enabled = true;
            
        }
    }
}

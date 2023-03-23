using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingProjectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField] private float radius = 1f;
    private Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
        Launch();
    }


    void Launch()
    {
        rigidBody.AddExplosionForce(speed, transform.localPosition, radius, 3f);
        rigidBody.AddForce(transform.forward * speed);
        
    }
    
    void Update()
    {
        
    }
}

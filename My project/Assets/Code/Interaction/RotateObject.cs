using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LemonForest.Environment.DayTime;

public class RotateObject : MonoBehaviour
{
    public GameObject lightObject;

    public float degreesPerSecond = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeStateManager.Instance.CurrentState.Type.Equals(DayState.Evening) || TimeStateManager.Instance.CurrentState.Type.Equals(DayState.Midnight) || TimeStateManager.Instance.CurrentState.Type.Equals(DayState.Afternoon))
        {
            lightObject.active = true;
            transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
        }
        else
        {
            lightObject.active = false;
        }
    }
}

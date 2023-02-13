using LemonForest.Environment.DayTime;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

namespace LemonForest.Environment
{
    public class LightController : MonoBehaviour
    {
        [SerializeField]
        protected GameObject sun, moon;

        private Light sunLight, moonLight;
        private float rotationSpeed;

        private bool day;

        private float triggerAngle = 0.2f;

        private Color lerp;



        // Start is called before the first frame update
        void Start()
        {
            sunLight = sun.GetComponent<Light>();
            moonLight = moon.GetComponent<Light>();
            rotationSpeed = 360 / StaticVariables.secondsInDay;

            if (sun == null) { sun = GameObject.Find("Sun"); }
            if (moon == null) { moon = GameObject.Find("Moon"); }

            moonLight.color = TimeStateManager.Instance.GetState(DayState.Midnight).GetColor();
        }

        // Update is called once per frame
        void Update()
        {
            ManageLight(sun, sunLight, triggerAngle);
            ManageLight(moon, moonLight, triggerAngle);


            
            lerp = Color.Lerp(TimeStateManager.Instance.GetState(TimeStateManager.Instance.CurrentColored).GetColor(),
                TimeStateManager.Instance.GetState(TimeStateManager.Instance.NextColored).GetColor(),
                TimeStateManager.Instance.GetStateProgress());

            sunLight.color = lerp;
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }

        private void ManageLight(GameObject lightHolder, Light light, float triggerAngle)
        {
            if(lightHolder.transform.forward.y > triggerAngle)
            {
                light.enabled = false;
            }
            else
            {
                light.enabled = true;
            }
        }

        
    }
}

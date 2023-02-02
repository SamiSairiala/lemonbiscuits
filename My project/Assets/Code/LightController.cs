using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LemonForest.Environment
{
    public class LightController : MonoBehaviour
    {
        [SerializeField]
        protected GameObject sun, moon;

        private Light sunLight, moonLight;
        private float rotationSpeed = 5;

        private bool day;

        [SerializeField]
        private Color morningColor = new Color(255, 105, 112);
        [SerializeField]
        private Color noonColor = new Color(255, 244, 214);
        [SerializeField]
        private Color eveningColor;
        [SerializeField]
        private Color moonColor;
        [SerializeField]
        private float triggerAngle = 0.2f;


        // Start is called before the first frame update
        void Start()
        {
            sunLight = sun.GetComponent<Light>();
            moonLight = moon.GetComponent<Light>();
            moonLight.color = moonColor;

            if (sun == null) { sun = GameObject.Find("Sun"); }
            if (moon == null) { moon = GameObject.Find("Moon"); }
        }

        // Update is called once per frame
        void Update()
        {
            ManageLight(sun, sunLight, triggerAngle);
            ManageLight(moon, moonLight, triggerAngle);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LemonForest.Environment
{
    public class LightController : MonoBehaviour
    {
        [SerializeField]
        protected GameObject sun, moon;
        private Color morningColor, noonColor;

        private Light sunLight, moonLight;
        private float rotationSpeed = 5;

        private bool day;

        // Start is called before the first frame update
        void Start()
        {
            morningColor = new Color(255, 105, 112);
            noonColor = new Color(255, 244, 214);

            sunLight = sun.GetComponent<Light>();
            moonLight = moon.GetComponent<Light>();

            if (sun == null) { sun = GameObject.Find("Sun"); }
            if (moon == null) { moon = GameObject.Find("Moon"); }
        }

        // Update is called once per frame
        void Update()
        {
            if(sun.transform.forward.y <= 0)
            {
                sunLight.enabled = true;
                moonLight.enabled = false;
            } else
            {
                sunLight.enabled = false;
                moonLight.enabled = true;
            }
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }
    }
}

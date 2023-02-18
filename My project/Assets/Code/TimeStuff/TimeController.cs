using UnityEngine;
namespace LemonForest.Environment.DayTime
{
    public class TimeController : MonoBehaviour
    {
        private static TimeController instance;
        public float CurrentTime { get; private set; }

        public static TimeController Instance
        {
            get
            {
                if (instance == null)
                {
                    TimeController prefab = Resources.Load<TimeController>(typeof(TimeController).Name);

                    instance = Instantiate(prefab);
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null) { instance = this; }
            else if (instance != this) { Destroy(this); return; }

            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            CurrentTime = 0.25f * StaticVariables.secondsInDay;
        }

        // Update is called once per frame
        void Update()
        {
            CurrentTime = (CurrentTime + Time.deltaTime) % StaticVariables.secondsInDay;
            
            if(TimeStateManager.Instance.CurrentState.Type != GetCurrent())
            {
                TimeStateManager.Instance.GoNext();
            }
        }

        public DayState GetCurrent()
        {
            return GetCurrentState(CurrentTime % StaticVariables.secondsInDay);
        }

        public DayState GetCurrentState(float currentTime)
        {
            float secondsInDay = StaticVariables.secondsInDay;
            currentTime = currentTime % secondsInDay;

            if(currentTime < secondsInDay * 0.25f) { return DayState.EarlyMorning; }
            if(currentTime < secondsInDay * 0.5f) { return DayState.Morning; }
            if(currentTime < secondsInDay * 0.75f) { return DayState.Afternoon; }
            if(currentTime < secondsInDay) { return DayState.Evening; }

            return DayState.Error;
        }
    }
}


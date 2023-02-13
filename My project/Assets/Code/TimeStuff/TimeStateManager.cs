using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LemonForest.Environment.DayTime
{
    public class TimeStateManager : MonoBehaviour
    {
        private static TimeStateManager instance;

        [SerializeField]
        private Color morningColor = new Color(255, 105, 112);
        [SerializeField]
        private Color noonColor = new Color(255, 244, 214);
        [SerializeField]
        private Color eveningColor;
        [SerializeField]
        private Color moonColor;
        [SerializeField]

        public static TimeStateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    TimeStateManager prefab = Resources.Load<TimeStateManager>(typeof(TimeStateManager).Name);

                    instance = Instantiate(prefab);
                }
                return instance;
            }
        }

        private List<TimeStateBase> states = new List<TimeStateBase>();

        public TimeStateBase CurrentState { get; private set; }
        public TimeStateBase PreviousState { get; private set; }
        public DayState CurrentColored { get; private set; }
        public DayState NextColored { get; private set; }

        private void Awake()
        {
            if (instance == null) { instance = this; }
            else if (instance != this) { Destroy(this); return; }

            DontDestroyOnLoad(gameObject);

            Initialize();
        }

        private void Initialize()
        {
            MidnightState midnight = new MidnightState();
            EarlyMorningState earlyMorning = new EarlyMorningState();
            SunriseState sunrise = new SunriseState();
            sunrise.SetColor(morningColor);
            MorningState morning = new MorningState();
            NoonState noon = new NoonState();
            noon.SetColor(noonColor);
            AfternoonState afterNoon = new AfternoonState();
            SunsetState sunset = new SunsetState();
            sunset.SetColor(eveningColor);
            EveningState evening = new EveningState();

            states.Add(midnight);
            states.Add(earlyMorning);
            states.Add(sunrise);
            states.Add(morning);
            states.Add(noon);
            states.Add(afterNoon);
            states.Add(sunset);
            states.Add(evening);



            if (CurrentState == null)
            {
                ActivateFirstScene(GetState(StaticVariables.startTime));
            }

        }

        private void ActivateFirstScene(TimeStateBase first, int index = 0)
        {
            CurrentState = first;
            CurrentColored = DayState.Sunrise;
            NextColored = GetNextColored(DayState.Sunrise);
        }

        public TimeStateBase GetState(DayState type)
        {
            foreach (TimeStateBase state in states)
            {
                if (state.Type == type)
                {
                    return state;
                }
            }
            return null;
        }

        public bool Go(DayState targetStateType, int levelIndex = 0)
        {
            Color temp = new Color();
            if (!CurrentState.IsValidTarget(targetStateType)) { return false; }

            TimeStateBase nextState = GetState(targetStateType);
            if (nextState == null) { return false; }

            if (nextState.GetColor() != temp)
            {
                CurrentColored = targetStateType;
                NextColored = GetNextColored(targetStateType);
            }

            PreviousState = CurrentState;
            CurrentState = nextState;

            return true;
        }

        public void GoNext()
        {
            Debug.Log("NextToD");
            Go(CurrentState.GetTargetDayState());
        }

        private DayState GetNextColored(DayState ds)
        {
            TimeStateBase tsb = TimeStateManager.Instance.GetState(ds);
            Color temp = new Color();
            for (int i = 0; i < 4; i++)
            {
                tsb = TimeStateManager.Instance.GetState(tsb.GetTargetDayState());
                if (tsb.GetColor() != temp)
                {
                    return tsb.Type;
                }
            }

            return DayState.Error;
        }

        public float GetStateProgress()
        {
            float secInDay = StaticVariables.secondsInDay;
            float startTime = GetState(CurrentColored).TriggerTime * secInDay;
            float endTime = GetState(NextColored).TriggerTime * secInDay - startTime;
            float tempStart = TimeController.Instance.CurrentTime - startTime;

            Debug.Log(tempStart / endTime);
            return tempStart / endTime;
        }
    }
}
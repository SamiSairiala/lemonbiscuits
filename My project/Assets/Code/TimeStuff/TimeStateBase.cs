using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonForest.Environment.DayTime
{
    public abstract class TimeStateBase
    {
        private int timeIndex = 0;
        private float triggerTime = -1f;

        public virtual float TriggerTime
        {
            get { return triggerTime; }
            protected set { triggerTime = value; }
        }

        private Color color;

        private DayState targetState = new DayState();

        public abstract string TimeName { get; }
        public abstract DayState Type { get; }
        
        public virtual int TimeIndex
        {
            get { return timeIndex; }
            protected set { timeIndex = value; }
        }

        protected TimeStateBase() { }

        protected void SetTargetState(DayState ts)
        {
            targetState = ts;
        }
        
        public DayState GetTargetDayState()
        {
            return targetState;
        }

        public void SetColor(Color c)
        {
            color = c;
        }

        public Color GetColor()
        {
            return color;
        }

        public bool IsValidTarget(DayState target)
        {
            if(target == targetState)
            {
                return true;
            }
            return false;
        }
    }
}

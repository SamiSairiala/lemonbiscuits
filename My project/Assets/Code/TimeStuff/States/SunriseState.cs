namespace LemonForest.Environment.DayTime
{
    public class SunriseState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Sunrise"; }
        }

        public override DayState Type
        {
            get { return DayState.Sunrise; }
        }

        public SunriseState() : base()
        {
            TriggerTime = 0.25f;
            SetTargetState(DayState.Morning);
        }
    }
}
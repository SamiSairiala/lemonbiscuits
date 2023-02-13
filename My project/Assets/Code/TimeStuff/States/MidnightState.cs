namespace LemonForest.Environment.DayTime
{
    public class MidnightState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Midnight"; }
        }

        public override DayState Type
        {
            get { return DayState.Midnight; }
        }

        public MidnightState() : base()
        {
            TriggerTime = 1;
            SetTargetState(DayState.EarlyMorning);
        }
    }
}
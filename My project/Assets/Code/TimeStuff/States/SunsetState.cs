namespace LemonForest.Environment.DayTime
{
    public class SunsetState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Sunset"; }
        }

        public override DayState Type
        {
            get { return DayState.Sunset; }
        }

        public SunsetState() : base()
        {
            TriggerTime = 0.75f;
            SetTargetState(DayState.Evening);
        }
    }
}


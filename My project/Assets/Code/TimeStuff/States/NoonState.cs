namespace LemonForest.Environment.DayTime
{
    public class NoonState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Noon"; }
        }

        public override DayState Type
        {
            get { return DayState.Noon; }
        }

        public NoonState() : base()
        {
            TriggerTime = 0.5f;
            SetTargetState(DayState.Afternoon);
        }
    }
}
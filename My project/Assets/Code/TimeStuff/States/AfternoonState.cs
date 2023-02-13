namespace LemonForest.Environment.DayTime
{
    public class AfternoonState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Afternoon"; }
        }

        public override DayState Type
        {
            get { return DayState.Afternoon; }
        }

        public AfternoonState() : base()
        {
            SetTargetState(DayState.Sunset);
        }
    }
}
namespace LemonForest.Environment.DayTime
{
    public class EarlyMorningState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Early Morning"; }
        }

        public override DayState Type
        {
            get { return DayState.EarlyMorning; }
        }

        public EarlyMorningState() : base()
        {
            SetTargetState(DayState.Sunrise);
        }
    }
}
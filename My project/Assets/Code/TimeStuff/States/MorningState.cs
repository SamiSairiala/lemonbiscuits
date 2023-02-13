namespace LemonForest.Environment.DayTime
{
    public class MorningState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Morning"; }
        }

        public override DayState Type
        {
            get { return DayState.Morning; }
        }

        public MorningState() : base()
        {
            SetTargetState(DayState.Noon);
        }
    }
}
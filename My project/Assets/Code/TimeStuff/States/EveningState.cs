namespace LemonForest.Environment.DayTime
{
    public class EveningState : TimeStateBase
    {
        public override string TimeName
        {
            get { return "Evening"; }
        }

        public override DayState Type
        {
            get { return DayState.Evening; }
        }

        public EveningState() : base()
        {
            SetTargetState(DayState.Midnight);
        }
    }
}


using LemonForest.Environment.DayTime;

namespace LemonForest
{
    public static class StaticVariables
    {
        public static int secondsInDay = 60;                  //How Many IRL Seconds are in a ingame day

        public static float NPCMovementSpeed = 3.5f;
        public static float NPCAcceleration = 8f;

        public static DayState startTime = DayState.Sunrise;    //which time does the game start in
        public static float sunRiseDuration = 0.2f;             // % of the day sunrise lasts (½ before and ½ after the moment sun points sideways)
        public static float sunSetDuration = sunRiseDuration;

    }
}
using LemonForest.Environment.DayTime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LemonForest.AI
{
    [Serializable]
    public struct RoutineAction
    {
        public DayState triggerTime;
        public ActionType actionType;
        public Transform location;

    }
}

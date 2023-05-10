using LemonForest.Environment.DayTime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace LemonForest.AI
{
    public class NPCBase : MonoBehaviour
    {
        [SerializeField]
        NavMeshAgent agent;
        [SerializeField]
        List<RoutineAction> routine;


        // Start is called before the first frame update
        private void Awake()
        {
            Setup();
        }

        private void Setup()
        {
            agent.speed = StaticVariables.NPCMovementSpeed;
            agent.acceleration = StaticVariables.NPCAcceleration;
        }

        // Update is called once per frame
        void Update()
        {
            DoThing(TimeController.Instance.GetCurrent());
        }

        public void PauseRoutine() 
        {
            agent.speed = 0;
        }

        public void ContinueRoutine()
        {
            agent.speed = StaticVariables.NPCMovementSpeed;
        }

        private void DoThing(DayState currentTime)
        {
            foreach (RoutineAction action in routine)
            {
                if(action.triggerTime == currentTime)
                {
                    if(action.actionType == ActionType.walkTo)
                    {
                        agent.SetDestination(action.location.position);
                    }
                } else
                {
                    continue;
                }
            }
        }
    }
}
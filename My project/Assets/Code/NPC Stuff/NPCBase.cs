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
            if (Input.GetMouseButtonDown(1))
            {
                Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(movePosition, out var hitInfo))
                {
                    agent.SetDestination(hitInfo.point);
                }
            }
        }
    }
}
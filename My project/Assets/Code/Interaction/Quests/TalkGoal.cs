using Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{


    public class TalkGoal : Goal
    {
        public TalkGoal(NewQuest quest, string description, bool completed, int currentCheckpoint, int requiredCheckpoint, GameObject npcGameobject) // Add gameobject here who to talk to maybe add more than one.
        {
            this.Quest = quest;
            this.Description = description;
            this.Completed = completed;
            this.CurrentAmount = currentCheckpoint;
            this.RequiredAmount = requiredCheckpoint;
            this.npcGameobject = npcGameobject;
        }

        public override void Init()
        {
            base.Init();
            PlayerMovement.WhoTalkedTo += Talked;
        }


        void Talked(GameObject gameObject)
        {
            if (gameObject.name.Equals(npcGameobject.name)) // Gameobject name here.
            {
                Debug.Log("Right npc");
                Debug.Log(CurrentAmount + " / " + RequiredAmount);
                CurrentAmount++;
                Evaluate(null);
            }
        }

    }
}

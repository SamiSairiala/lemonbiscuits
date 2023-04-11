using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // Name of NPC
    public string name;


    // Adding place to input text to dialogue from unity editor.
    [TextArea(3, 10)]
    public string[] sentences;

    [TextArea(3, 10)]
    public string[] secondQuestSentences;

    // Here to fill npc to talk something after player accepts quests etc.
    [TextArea(3, 10)]
    public string[] sentencesDuringQuests;

    [TextArea(3, 10)]
    public string[] AfterQuestSentences;

    [TextArea(3, 10)]
    public string[] hasDiffrentQuestSentences;

    [TextArea(3, 10)]
    public string[] CompletedQuest;
}

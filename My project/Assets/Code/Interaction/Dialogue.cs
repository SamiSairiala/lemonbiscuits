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

    [TextArea(3, 10)]
    public string[] thirdQuestSentences;

    [TextArea(3, 10)]
    public string[] FourthQuestSentences;

    // Here to fill npc to talk something after player accepts quests etc.
    [TextArea(3, 10)]
    public string[] sentencesDuringQuests;

    [TextArea(3, 10)]
    public string[] AfterQuestSentences;

    [TextArea(3, 10)]
    public string[] hasDiffrentQuestSentences;

    [TextArea(3, 10)]
    public string[] CompletedQuest;

    [TextArea(3, 10)]
    public string[] nextTwigQuest;

    [TextArea(3, 10)]
    public string[] nextRockieQuest;

    [TextArea(3, 10)]
    public string[] nextLaughyQuest;

    [TextArea(3, 10)]
    public string[] TalkQuest;

    [TextArea(3, 10)]
    public string[] SecondTalkQuest;

    [TextArea(3, 10)]
    public string[] FirstQuestDone;

    [TextArea(3, 10)]
    public string[] SecondQuestDone;

    [TextArea(3, 10)]
    public string[] ThirdQuestDone;

    [TextArea(3, 10)]
    public string[] FourthQuestDone;



    [TextArea(3, 10)]
    public string[] FailedQuestions;
}

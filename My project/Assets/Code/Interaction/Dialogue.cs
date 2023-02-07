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
}

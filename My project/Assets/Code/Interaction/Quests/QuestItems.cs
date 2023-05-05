using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItems : MonoBehaviour
{
    [Header("Required quest items")]
    public Item Flower;
    public Item Fish;
    public Item Apple;
    public Item Croissant;
    public Item Fishpie;
    public Item RareFlower;
    public Item Amulet;
        public GameObject AmuletGameobject;
    public GameObject RareFlowersHolder;


    [Header("Reward items")]
    public Item Coin;
    public Item FishingRod;
    public Item ApplePie;
    

    [Header("Needed items")]
    public Item Recipe;

    [Header("Quest NPC's")]
    public GameObject NPC1; // Rename These.
    public GameObject NPC2;
    public GameObject NPC3;

    public GameObject Arbor;
}

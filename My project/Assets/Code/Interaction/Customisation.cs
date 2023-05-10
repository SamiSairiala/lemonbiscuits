using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour
{


    [SerializeField] private GameObject BunnyEars;
    [SerializeField] private GameObject Tail1;
    [SerializeField] private GameObject Tail2;
    [SerializeField] private GameObject Tail3;
    [SerializeField] private GameObject Scarf;
    [SerializeField] private GameObject Sprout;

    [SerializeField] private GameObject BunnyEarsButton;
    [SerializeField] private GameObject Tail1Button;
    [SerializeField] private GameObject Tail2Button;
    [SerializeField] private GameObject Tail3Button;
    [SerializeField] private GameObject ScarfButton;
    [SerializeField] private GameObject SproutButton;

    public Item BunnyEarsItem;
    public Item Tail1Item;
    public Item Tail2Item;
    public Item Tail3Item;
    public Item ScarfItem;
    public Item SproutItem;


    public bool CanEquipEars = false;
    public bool CanEquipTail1 = false;
    public bool CanEquipTail2 = false;
    public bool CanEquipTail3 = false;
    public bool CanEquipScarf = false;
    public bool CanEquipSprout = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (InventoryManager.Instance.Items.Contains(BunnyEarsItem))
		{
            BunnyEarsButton.SetActive(true);
            CanEquipEars = true;
		}
        if (InventoryManager.Instance.Items.Contains(Tail1Item))
        {
            Tail1Button.SetActive(true);
            CanEquipTail1 = true;
        }
        if (InventoryManager.Instance.Items.Contains(Tail2Item))
        {
            Tail2Button.SetActive(true);
            CanEquipTail2 = true;
        }
        if (InventoryManager.Instance.Items.Contains(Tail3Item))
        {
            Tail3Button.SetActive(true);
            CanEquipTail3 = true;
        }
        if (InventoryManager.Instance.Items.Contains(SproutItem))
        {
            SproutButton.SetActive(true);
            CanEquipSprout = true;
        }
        if (InventoryManager.Instance.Items.Contains(ScarfItem))
        {
            ScarfButton.SetActive(true);
            CanEquipScarf = true;
        }
    }



    public void EquipEars()
	{
		if (CanEquipEars)
		{
            BunnyEars.SetActive(true);
		}
	}

    public void EquipTail1()
    {
		if (CanEquipTail1)
		{
            Tail1.SetActive(true);
            Tail2.SetActive(false);
            Tail3.SetActive(false);
		}
    }
    public void EquipTail2()
    {

		if (CanEquipTail2)
		{
            Tail2.SetActive(true);
            Tail1.SetActive(false);
            Tail3.SetActive(false);
        }
    }
    public void EquipTail3()
    {
		if (CanEquipTail3)
		{
            Tail3.SetActive(true);
            Tail2.SetActive(false);
            Tail1.SetActive(false);
        }
    }
    public void EquipScarf()
    {
		if (CanEquipScarf)
		{
            Scarf.SetActive(true);
		}
    }
    public void EquipSprout()
    {
		if (CanEquipSprout)
		{
            Sprout.SetActive(true);
		}
    }
}
